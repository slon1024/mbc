namespace MBC.UInteger
{
    /// <summary>
    /// Implementation of addition and subtraction operators for MbcUInteger
    /// </summary>
    public partial class MbcUInteger
    {
        /// <summary>
        /// Addition operator
        /// </summary>
        /// <see cref="MbcUInteger.CalcuateAddition"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>MbcUInteger</returns>
        public static MbcUInteger operator +(MbcUInteger a, MbcUInteger b)
        {
            return CalcuateAddition(a, b);
        }

        /// <summary>
        /// Subtraction operator
        /// </summary>
        /// <see cref="MbcUInteger.CalcuateSubtraction"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>MbcUInteger</returns>
        public static MbcUInteger operator -(MbcUInteger a, MbcUInteger b)
        {
            return (a < b)
                    ? null
                    : (a == b)
                        ? new MbcUInteger(0)
                        : CalcuateSubtraction(a, b);
        }


        /// <summary>
        /// Addition operator
        /// </summary>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>MbcUInteger</returns>
        protected static MbcUInteger CalcuateAddition(MbcUInteger a, MbcUInteger b)
        {
            return CommonCalculations(a, b, isAddition: true);
        }
        
        /// <summary>
        /// Subtraction operator
        /// </summary>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>MbcUInteger</returns>
        protected static MbcUInteger CalcuateSubtraction(MbcUInteger a, MbcUInteger b)
        {
            return CommonCalculations(a, b, isAddition: false);

        }

        /// <summary>
        /// The common implementation for the addition and subtraction.
        /// It is very similar except for a few details.
        /// </summary>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <param name="isAddition">Whether it is addition?</param>
        /// <returns>MbcUInteger</returns>
        private static MbcUInteger CommonCalculations(MbcUInteger a, MbcUInteger b, bool isAddition)
        {
            var greaterNumber = a.ToString();
            var equalOrLessNumber = b.ToString();
            if (equalOrLessNumber.Length > greaterNumber.Length)
                Swap(ref greaterNumber, ref equalOrLessNumber);

            int indexDiff = greaterNumber.Length - equalOrLessNumber.Length;
            int buffer = 0;
            var result = AllocateMemory<int>(greaterNumber.Length + 1);

            var operation = isAddition ? OperationAdd : new Operation(OperationSub);
            for (int index = greaterNumber.Length - 1; index > -1; index--)
            {
                var value = GetIntFromChar(greaterNumber[index]) + buffer;
                buffer = 0;
                operation(equalOrLessNumber, index, indexDiff, ref value);//delegate
                result[index + 1] = PrepareDigitValue(value, ref buffer);
            }

            if( isAddition )
                result[0] = buffer;
            return new MbcUInteger(result);
        }

        delegate void Operation(string equalOrLessNumber, int index, int indexDiff, ref int value);

        /// <summary>
        /// Used for addition like a delegate Operation
        /// </summary>
        /// <see cref="MbcUInteger.CommonCalculations"/>
        private static void OperationAdd(string equalOrLessNumber, int index, int indexDiff, ref int value)
        {
            if (index >= indexDiff)
                value += GetIntFromChar(equalOrLessNumber[index - indexDiff]);
        }

        /// <summary>
        /// Used for subtraction like a delegate Operation
        /// </summary>
        /// <see cref="MbcUInteger.CommonCalculations"/>
        private static void OperationSub(string equalOrLessNumber, int index, int indexDiff, ref int value)
        {
            if (index - indexDiff > -1)
                value -= GetIntFromChar(equalOrLessNumber[index - indexDiff]);
        }
    }
}