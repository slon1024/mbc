namespace MBC.Integer
{
    public partial class MbcInteger
    {
        public static MbcInteger operator *(MbcInteger a, MbcInteger b)
        {
            return CalcuateMultiplication(a, b);
        }

        public static MbcInteger operator /(MbcInteger a, MbcInteger b)
        {
            return CalcuateDivision(a, b);
        }

        public static MbcInteger operator %(MbcInteger a, MbcInteger b)
        {
            return CalcuateModulo(a, b);
        }

        protected static MbcInteger CalcuateMultiplication(MbcInteger a, MbcInteger b)
        {
            var sign = SignValue.Positive;
            if ((a.IsPositive && b.IsNegative) || (a.IsNegative && b.IsPositive))
                sign = SignValue.Negative;

            return new MbcInteger(CalcuateMultiplication(a.ToMbcUInteger(), b.ToMbcUInteger())) { _sign = sign };
        }

        protected static MbcInteger CalcuateDivision(MbcInteger a, MbcInteger b)
        {
            var sign = SignValue.Positive;
            if ((a.IsPositive && b.IsNegative) || (a.IsNegative && b.IsPositive))
                sign = SignValue.Negative;

            return new MbcInteger(CalcuateDivision(a.ToMbcUInteger(), b.ToMbcUInteger())) { _sign = sign };
        }

        protected static MbcInteger CalcuateModulo(MbcInteger a, MbcInteger b)
        {
            if ((a.IsPositive && b.IsPositive) || (a.IsNegative && b.IsNegative))
                return new MbcInteger(CalcuateModulo(a.ToMbcUInteger(), b.ToMbcUInteger())) { _sign = a.Sign };

            var quotient = new MbcInteger(a.ToMbcUInteger() / b.ToMbcUInteger()) + new MbcInteger("1");
            var rest = a + (quotient * b);

            return new MbcInteger(rest);
        }
    }
}