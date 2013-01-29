namespace MBC.Integer
{
    /// <summary>
    /// Implementation of addition and subtraction operators for MbcInteger
    /// </summary>
    public partial class MbcInteger
    {
        /// <summary>
        /// Addition operator
        /// </summary>
        /// <see cref="MbcInteger.CalcuateAddition"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>MbcInteger</returns>
        public static MbcInteger operator +(MbcInteger a, MbcInteger b)
        {
            return CalcuateAddition(a, b);
        }

        /// <summary>
        /// Subtraction operator
        /// </summary>
        /// <see cref="MbcInteger.CalcuateSubtraction"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>MbcInteger</returns>
        public static MbcInteger operator -(MbcInteger first, MbcInteger second)
        {
            return CalcuateSubtraction(first, second);
        }

        /// <summary>
        /// Implementation of the addition of numbers
        /// </summary>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>MbcInteger</returns>
        protected static MbcInteger CalcuateAddition(MbcInteger a, MbcInteger b)
        {
            var first = a.ToMbcUInteger();
            var second = b.ToMbcUInteger();
            if (a.IsPositive && b.IsPositive || a.IsNegative && b.IsNegative)
                return new MbcInteger(CalcuateAddition(first, second)) { _sign = a._sign };

            var sign = SignValue.Positive;
            var isGreater = IsGreater(first, second);
            if ((a.IsNegative && b.IsPositive && true == isGreater)
                || (a.IsPositive && b.IsNegative && false == isGreater))
                sign = SignValue.Negative;

            if ((a.IsNegative && b.IsPositive && false == isGreater) || false == isGreater)
                Swap(ref first, ref second);

            return new MbcInteger(CalcuateSubtraction(first, second)) { _sign = sign };
        }

        /// <summary>
        /// Implementation of the subtraction of numbers
        /// </summary>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>MbcInteger</returns>
        protected static MbcInteger CalcuateSubtraction(MbcInteger a, MbcInteger b)
        {
            var first = a.ToMbcUInteger();
            var second = b.ToMbcUInteger();
            var sign = SignValue.Positive;

            if (a.IsPositive && b.IsNegative || a.IsNegative && b.IsPositive)
            {
                if (a.IsNegative) sign = SignValue.Negative;
                return new MbcInteger(CalcuateAddition(first, second)) { _sign = sign };
            }

            var isGreater = IsGreater(first, second);
            if ((a.IsPositive && b.IsPositive && false == isGreater)
                 || (a.IsNegative && b.IsNegative))
                Swap(ref first, ref second);

            if ((a.IsPositive && b.IsPositive && false == isGreater)
                || (a.IsNegative && b.IsNegative && true == isGreater))
                sign = SignValue.Negative;

            return new MbcInteger(CalcuateSubtraction(first, second)) { _sign = sign };
        }
    }
}