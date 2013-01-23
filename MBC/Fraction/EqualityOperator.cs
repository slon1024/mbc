namespace MBC.Fraction
{
    public partial class MbcFraction
    {
        public static bool operator ==(MbcFraction a, MbcFraction b)
        {
            return IsEqual(a, b);
        }

        public static bool operator !=(MbcFraction a, MbcFraction b)
        {
            return false == (a == b);
        }

        protected static bool IsEqual(MbcFraction a, MbcFraction b)
        {
            return (a.Numerator == b.Numerator
                    && a.Denominator == b.Denominator
                    && a.Sign == b.Sign);
        }
    }
}