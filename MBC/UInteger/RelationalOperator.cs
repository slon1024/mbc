namespace MBC.UInteger
{
    public partial class MbcUInteger
    {
        public static bool operator >(MbcUInteger a, MbcUInteger b)
        {
            return IsGreater(a, b);
        }

        public static bool operator >(string a, MbcUInteger b)
        {
            return IsGreater(new MbcUInteger(a), b);
        }

        public static bool operator >(MbcUInteger a, string b)
        {
            return IsGreater(a, new MbcUInteger(b));
        }

        public static bool operator <(MbcUInteger a, MbcUInteger b)
        {
            return IsLess(a, b);
        }

        public static bool operator <(string a, MbcUInteger b)
        {
            return IsLess(new MbcUInteger(a), b);
        }

        public static bool operator <(MbcUInteger a, string b)
        {
            return IsLess(a, new MbcUInteger(b));
        }

        public static bool operator >=(MbcUInteger a, MbcUInteger b)
        {
            return IsGreaterOrEqual(a, b);
        }

        public static bool operator <=(MbcUInteger a, MbcUInteger b)
        {
            return IsLessOrEqual(a, b);
        }

        protected static bool IsGreater(MbcUInteger a, MbcUInteger b)
        {
            if (a.Length < b.Length)
                return false;

            if (a.Length > b._length || a.Cell < 1)
                return true;

            if (a._integer.Count > 1)
            {
                for (int i = 0; i < a.Cell; i++)
                    if (a._integer[i] < b._integer[i])
                        return false;
            }

            return a._integer[a.Cell - 1] > b._integer[a.Cell - 1];
        }

        protected static bool IsGreaterOrEqual(MbcUInteger a, MbcUInteger b)
        {
            return IsEqual(a, b) || IsGreater(a, b);
        }

        protected static bool IsLess(MbcUInteger a, MbcUInteger b)
        {
            return false == (IsEqual(a, b) || IsGreater(a, b));
        }

        protected static bool IsLessOrEqual(MbcUInteger a, MbcUInteger b)
        {
            return IsEqual(a, b) || false == IsGreater(a, b);
        }
    }
}