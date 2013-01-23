namespace MBC.Integer
{
    public partial class MbcInteger
    {
        public static bool operator ==(MbcInteger a, MbcInteger b)
        {
            if (a.Sign != b.Sign)
                return false;

            return IsEqual(a, b);
        }

        public static bool operator !=(MbcInteger a, MbcInteger b)
        {
            return false == (a == b);
        }
    }
}