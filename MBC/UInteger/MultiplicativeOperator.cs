using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MBC.UInteger
{
    /// <summary>
    /// Is like classical type uint, with one difference being that there are no restrictions in top border.
    /// This means that the count from zero to plus infinity.
    /// </summary>
    public partial class MbcUInteger
    {
        /// <summary>
        /// Returns the result of the multiplication of two numbers.
        /// Implementation of the calculation is in the method CalcuateMultiplication.
        /// </summary>
        /// <see cref="CalcuateMultiplication"/>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <returns>result of the multiplication of two numbers</returns>
        public static MbcUInteger operator *(MbcUInteger first, MbcUInteger second)
        {
            return CalcuateMultiplication(first, second);
        }

        /// <summary>
        /// Returns the result of the multiplication of two numbers (MbcUInteger times uint).
        /// </summary>
        /// <param name="a">first number, type MbcUInteger</param>
        /// <param name="b">second number, type uint</param>
        /// <returns>result of the multiplication of two numbers</returns>
        public static MbcUInteger operator *(MbcUInteger a, uint b)
        {
            return CalcuateMultiplication(a, new MbcUInteger(b));
        }

        public static MbcUInteger operator *(uint a, MbcUInteger b)
        {
            return CalcuateMultiplication(new MbcUInteger(a), b);
        }

        #region CalcuateMultiplication

        protected static MbcUInteger CalcuateMultiplication(MbcUInteger a, MbcUInteger b)
        {
            if (1 == a.Length)
            {
                if ("0" == a.ToString())
                    return new MbcUInteger("0");

                if ("1" == a.ToString())
                    return new MbcUInteger(b);
            }

            if (1 == b.Length)
            {
                if ("0" == b.ToString())
                    return new MbcUInteger("0");

                if ("1" == b.ToString())
                    return new MbcUInteger(a);
            }

            bool aIsLessB = (a.Length < b.Length);
            var greaterNumber = (aIsLessB) ? b.ToString() : a.ToString();
            var equalOrLessNumber = (aIsLessB) ? a.ToString() : b.ToString();

            //allocate memory
            var result = new int[equalOrLessNumber.Length, greaterNumber.Length + 1];
            var output = new int[greaterNumber.Length + equalOrLessNumber.Length + 2];

            int buffer = 0;
            for (int outerIndex = equalOrLessNumber.Length - 1; outerIndex > -1; outerIndex--)
            {
                for (int innerIndex = greaterNumber.Length - 1; innerIndex > -1; innerIndex--)
                {
                    int value = GetIntFromChar(equalOrLessNumber[outerIndex]) * GetIntFromChar(greaterNumber[innerIndex]);
                    Carry(ref value, ref buffer);
                    result[equalOrLessNumber.Length - 1 - outerIndex, innerIndex + 1] = value;
                }

                if (buffer <= 0) continue;

                result[equalOrLessNumber.Length - 1 - outerIndex, 0] = buffer;
                buffer = 0;
            }

            //first stage
            for (int outerIndex = greaterNumber.Length; outerIndex > -1; outerIndex--)
            {
                int value = 0;

                for (int innerIndex = 0; innerIndex < equalOrLessNumber.Length; innerIndex++)
                {
                    int index = outerIndex + innerIndex;
                    if (index > greaterNumber.Length)
                        break;

                    value += result[innerIndex, index];
                }

                Carry(ref value, ref buffer);
                output[output.Length - 1 - (greaterNumber.Length - outerIndex)] = value;
            }

            //second stage
            for (int outerIndex = 1; outerIndex < equalOrLessNumber.Length; outerIndex++)
            {
                int value = 0;

                for (int innerIndex = 0; innerIndex < equalOrLessNumber.Length - outerIndex; innerIndex++)
                    value += result[outerIndex, innerIndex];

                Carry(ref value, ref buffer);
                output[output.Length - 1 - greaterNumber.Length - outerIndex] = value;
            }
            return new MbcUInteger(output);
        }

        #endregion CalcuateMultiplication

        public static MbcUInteger operator /(MbcUInteger a, MbcUInteger b)
        {
            return CalcuateDivision(a, b);
        }

        protected static MbcUInteger CalcuateDivision(MbcUInteger a, MbcUInteger b)
        {
            //border cases
            if (1 == b.Length)
            {
                if ("0" == b.ToString())
                    throw new DivideByZeroException("Division by constant zero");

                if ("1" == b.ToString())
                    return new MbcUInteger(a);
            }

            if (a == b)
                return new MbcUInteger("1");

            if ((1 == a.Length && "0" == a.ToString()) || a < b)
                return new MbcUInteger("0");

            //real cases
            return Div(a, b);
        }

        private static string GetFirstNumber(string dividend, string divider)
        {
            Debug.Assert(
                false == String.IsNullOrEmpty(dividend),
                "Dividend is empty or null",
                "The dividend can't be empty or null. This case should have been caught by the above conditions and should not reach the performance of this line"
            );

            Debug.Assert(
                false == String.IsNullOrEmpty(divider),
                "Divider is empty or null",
                "The divider can't be empty or null. This case should have been caught by the above conditions and should not reach the performance of this line"
            );

            return dividend.Substring(0, divider.Length);
        }

        private static void DevPart(string strDividend, string strDivider, out uint quotient, out string rest)
        {
            quotient = 0;
            rest = "0";

            var dividend = new MbcUInteger(strDividend);
            var divider = new MbcUInteger(strDivider);
            if (dividend < divider)
            {
                quotient = 0;
                rest = dividend.ToString();
            }
            else if (dividend == divider)
            {
                quotient = 1;
                rest = "0";
            }
            else
            {
                for (uint i = 2; i < 11; i++)
                {
                    var result = divider * i;
                    if (result > dividend)
                    {
                        quotient = i - 1;
                        var res = (dividend - (divider * quotient));
                        rest = (null == res) ? "" : res.ToString();
                        break;
                    }
                }
            }
        }

        private static MbcUInteger Div(MbcUInteger a, MbcUInteger b)
        {
            var dividend = a.ToString();
            var divider = b.ToString();
            var result = new List<uint>();

            var current = GetFirstNumber(dividend, divider);
            var lastIndex = current.Length;

            while (true)
            {
                uint quotient;
                string rest;

                DevPart(current, divider, out quotient, out rest);
                result.Add(quotient);
                if (false == lastIndex < dividend.Length)
                    break;
                current = rest + dividend[lastIndex++];
            }

            return new MbcUInteger(result);
        }

        public static MbcUInteger operator %(MbcUInteger a, MbcUInteger b)
        {
            if (1 == b.Length)
            {
                if ("0" == b.ToString())
                    throw new DivideByZeroException();

                if ("1" == b.ToString())
                    return new MbcUInteger("0");
            }

            if ((1 == a.Length && "0" == a.ToString())
                || a == b
                || a < b)
            {
                return new MbcUInteger("0");
            }

            return CalcuateModulo(a, b);
        }

        protected static MbcUInteger CalcuateModulo(MbcUInteger a, MbcUInteger b)
        {
            var quotient = a / b;
            var rest = a - (quotient * b);

            return rest;
        }
    }
}