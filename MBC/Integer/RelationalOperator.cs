namespace MBC.Integer
{
    public partial class MbcInteger
    {
        public static bool operator >(MbcInteger a, MbcInteger b)
        {
            return IsGreater(a, b);
        }

        public static bool operator <(MbcInteger a, MbcInteger b)
        {
            return IsLess(a, b);
        }

        public static bool operator >=(MbcInteger a, MbcInteger b)
        {
            return IsGreaterOrEqual(a, b);
        }

        public static bool operator <=(MbcInteger a, MbcInteger b)
        {
            return IsLessOrEqual(a, b);
        }

        protected static bool IsGreater(MbcInteger a, MbcInteger b)
        {
            if (a.IsNegative && b.IsPositive)
                return false;
            if (a.IsPositive && b.IsNegative)
                return true;
            if (a.IsNegative && b.IsNegative)
                return IsGreater(b.ToMbcUInteger(), a.ToMbcUInteger());//swap (a, b) -> (b, a)

            return IsGreater(a.ToMbcUInteger(), b.ToMbcUInteger());
        }

        protected static bool IsLess(MbcInteger a, MbcInteger b)
        {
            if (a.IsNegative && b.IsPositive)
                return true;
            if (a.IsPositive && b.IsNegative)
                return false;
            if (a.IsNegative && b.IsNegative)
                return IsLess(b.ToMbcUInteger(), a.ToMbcUInteger());//swap (a, b) -> (b, a)

            return IsLess(a.ToMbcUInteger(), b.ToMbcUInteger());
        }

        protected static bool IsGreaterOrEqual(MbcInteger a, MbcInteger b)
        {
            return IsEqual(a, b) || IsGreater(a, b);
        }

        protected static bool IsLessOrEqual(MbcInteger a, MbcInteger b)
        {
            return IsEqual(a, b) || false == IsGreater(a, b);
        }
    }
}