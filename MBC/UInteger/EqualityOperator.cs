namespace MBC.UInteger
{
    public partial class MbcUInteger
    {
        public static bool operator ==(MbcUInteger a, MbcUInteger b)
        {
            return IsEqual(a, b);
        }

        public static bool operator !=(MbcUInteger a, MbcUInteger b)
        {
            return false == (a == b);
        }

        protected static bool IsEqual(MbcUInteger a, MbcUInteger b)
        {
            if (a.Length != b.Length)
                return false;

            for (var i = 0; i < a._integer.Count; i++)
                if (a._integer[i] != b._integer[i])
                    return false;

            return true;
        }
    }
}