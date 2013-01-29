using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MBC.UInteger
{
    /// <summary>
    /// Implementation of multiplication, division and modulo operators for MbcUInteger.
    /// </summary>
    public partial class MbcUInteger
    {
        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <see cref="MbcUInteger.CalcuateMultiplication"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">uint - second number</param>
        /// <returns>MbcUInteger</returns>
        public static MbcUInteger operator *(MbcUInteger a, MbcUInteger b)
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

            return CalcuateMultiplication(a, b);
        }

        /// <summary>
        /// Multiplication operator.
        /// First argument is uint.
        /// </summary>
        /// <see cref="MbcUInteger.CalcuateMultiplication"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">uint - second number</param>
        /// <returns>MbcUInteger</returns>
        public static MbcUInteger operator *(uint a, MbcUInteger b)
        {
            return new MbcUInteger(a)*b;
        }

        /// <summary>
        /// Multiplication operator.
        /// Second argument is uint.
        /// </summary>
        /// <see cref="MbcUInteger.CalcuateMultiplication"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">uint - second number</param>
        /// <returns>MbcUInteger</returns>
        public static MbcUInteger operator *(MbcUInteger a, uint b)
        {
            return a*new MbcUInteger(b);
        }
        #region CalcuateMultiplication

        /// <summary>
        /// Implementation of multiplication 
        /// 
        /// Long multiplication
        ///     123
        ///    x 99
        ///     ---
        ///    1107
        ///   1107
        ///  ------
        ///   12177
        /// 
        /// </summary>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>MbcUInteger</returns>
        protected static MbcUInteger CalcuateMultiplication(MbcUInteger a, MbcUInteger b)
        {
            var greaterNumber = a.ToString();
            var equalOrLessNumber = b.ToString();
            if (greaterNumber.Length < equalOrLessNumber.Length)
                Swap(ref greaterNumber, ref equalOrLessNumber);

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

        /// <summary>
        /// Division operator
        /// </summary>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>MbcUInteger</returns>
        public static MbcUInteger operator /(MbcUInteger a, MbcUInteger b)
        {
            if (1 == b.Length)
            {
                if ("0" == b.ToString())
                    throw new DivideByZeroException("Division by constant zero");

                if ("1" == b.ToString())
                    return new MbcUInteger(a);
            }
            if (a == b)
                return new MbcUInteger("1");

            return CalcuateDivision(a, b);
        }

        /// <summary>
        /// Implementation division
        /// </summary>
        /// <see 
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>MbcUInteger</returns>
        protected static MbcUInteger CalcuateDivision(MbcUInteger a, MbcUInteger b)
        {

            if ((1 == a.Length && "0" == a.ToString()) || a < b)
                return new MbcUInteger("0");

            var dividend = a.ToString();
            var divider = b.ToString();
            var result = new List<uint>();

            var current = dividend.Substring(0, divider.Length);
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

        /// <summary>
        /// Performs a one step of division
        /// </summary>
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
                        rest = (dividend - (divider * quotient)).ToString();
                        break;
                    }
                }
            }
        }

        
        /// <summary>
        /// Modulo operator
        /// </summary>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>MbcUInteger</returns>
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

        /// <summary>
        /// Implementation modulo
        /// </summary>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>MbcUInteger</returns>
        protected static MbcUInteger CalcuateModulo(MbcUInteger a, MbcUInteger b)
        {
            var quotient = a / b;
            var rest = a - (quotient * b);

            return rest;
        }
    }
}