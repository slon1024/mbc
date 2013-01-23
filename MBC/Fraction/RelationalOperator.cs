using MBC.Integer;

namespace MBC.Fraction
{
    public partial class MbcFraction
    {
        public static bool operator >(MbcFraction a, MbcFraction b)
        {
            return IsGreater(a, b);
        }

        public static bool operator <(MbcFraction a, MbcFraction b)
        {
            return IsLess(a, b);
        }

        public static bool operator >=(MbcFraction a, MbcFraction b)
        {
            return IsGreaterOrEqual(a, b);
        }

        public static bool operator <=(MbcFraction a, MbcFraction b)
        {
            return IsLessOrEqual(a, b);
        }

        protected static bool IsGreater(MbcFraction a, MbcFraction b)
        {
            var first = new MbcInteger(a.Numerator * b.Denominator) { Sign = a.Sign };

            var second = a.Denominator * b.Numerator;
            if (b.IsNegative)
                b.SetNegative();

            return IsGreater(first, second);
        }

        protected static bool IsLess(MbcFraction a, MbcFraction b)
        {
            var first = new MbcInteger(a.Numerator * b.Denominator);
            if (a.IsNegative)
                first.SetNegative();

            var second = a.Denominator * b.Numerator;
            if (b.IsNegative)
                b.SetNegative();

            return IsLess(first, second);
        }

        protected static bool IsGreaterOrEqual(MbcFraction a, MbcFraction b)
        {
            return IsEqual(a, b) || IsGreater(a, b);
        }

        protected static bool IsLessOrEqual(MbcFraction a, MbcFraction b)
        {
            return IsEqual(a, b) || false == IsGreater(a, b);
        }
    }
}