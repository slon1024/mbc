namespace MBC.Fraction
{
    public partial class MbcFraction
    {
        public static MbcFraction operator *(MbcFraction a, MbcFraction b)
        {
            return CalcuateMultiplication(a, b);
        }

        public static MbcFraction operator /(MbcFraction a, MbcFraction b)
        {
            return CalcuateDivision(a, b);
        }

        protected static MbcFraction CalcuateMultiplication(MbcFraction a, MbcFraction b)
        {
            var sign = SignMultiplicativeOperator(a, b);
            return new MbcFraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator, sign);
        }

        protected static MbcFraction CalcuateDivision(MbcFraction a, MbcFraction b)
        {
            var sign = SignMultiplicativeOperator(a, b);
            return new MbcFraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator, sign);
        }

        private static SignValue SignMultiplicativeOperator(MbcFraction a, MbcFraction b)
        {
            var sign = SignValue.Positive;
            if ((a.IsNegative && b.IsPositive) || (a.IsPositive && b.IsNegative))
                sign = SignValue.Negative;

            return sign;
        }
    }
}