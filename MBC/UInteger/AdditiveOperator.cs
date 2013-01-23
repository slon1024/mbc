namespace MBC.UInteger
{
    public partial class MbcUInteger
    {
        public static MbcUInteger operator +(MbcUInteger a, MbcUInteger b)
        {
            return CalcuateAddition(a, b);
        }

        protected static MbcUInteger CalcuateAddition(MbcUInteger a, MbcUInteger b)
        {
            bool aIsLessB = (a.Length < b.Length);
            var greaterNumber = (aIsLessB) ? b.ToString() : a.ToString();
            var equalOrLessNumber = (aIsLessB) ? a.ToString() : b.ToString();
            int indexDiff = greaterNumber.Length - equalOrLessNumber.Length;
            int buffer = 0;

            var result = new int[greaterNumber.Length + 1];

            for (int index = greaterNumber.Length - 1; index > -1; index--)
            {
                var value = GetIntFromChar(greaterNumber[index]) + buffer;
                buffer = 0;
                if (index >= indexDiff)
                    value += GetIntFromChar(equalOrLessNumber[index - indexDiff]);

                result[index + 1] = PrepareDigitValue(value, ref buffer);
            }
            result[0] = buffer;

            return new MbcUInteger(result);
        }

        //SUBTRACTION
        public static MbcUInteger operator -(MbcUInteger a, MbcUInteger b)
        {
            return (a < b)
                    ? null
                    : (a == b)
                        ? new MbcUInteger(0)
                        : CalcuateSubtraction(a, b);
        }

        protected static MbcUInteger CalcuateSubtraction(MbcUInteger a, MbcUInteger b)
        {
            bool aIsLessB = (a.Length < b.Length);
            var greaterNumber = (aIsLessB) ? b.ToString() : a.ToString();
            var equalOrLessNumber = (aIsLessB) ? a.ToString() : b.ToString();
            int indexDiff = greaterNumber.Length - equalOrLessNumber.Length;
            int buffer = 0;
            var result = new int[greaterNumber.Length];

            for (int index = greaterNumber.Length - 1; index > -1; index--)
            {
                var value = GetIntFromChar(greaterNumber[index]) + buffer;
                buffer = 0;
                if (index - indexDiff > -1)
                    value -= GetIntFromChar(equalOrLessNumber[index - indexDiff]);

                result[index] = PrepareDigitValue(value, ref buffer);
            }

            return new MbcUInteger(result);
        }
    }
}