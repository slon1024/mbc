using System;
using MBC.Integer;

namespace MBC.Fraction
{
    public partial class MbcFraction
    {
        public static MbcFraction operator +(MbcFraction a, MbcFraction b)
        {
            return CalcuateAddition(a, b);
        }

        public static MbcFraction operator -(MbcFraction a, MbcFraction b)
        {
            return CalcuateSubtraction(a, b);
        }

        protected static MbcFraction CalcuateAddition(MbcFraction a, MbcFraction b)
        {
            return BaseCalcuateAdditiveOperator(a, b, (x, y) => x + y);
        }

        protected static MbcFraction CalcuateSubtraction(MbcFraction a, MbcFraction b)
        {
            return BaseCalcuateAdditiveOperator(a, b, (x, y) => x - y);
        }

        private static MbcFraction BaseCalcuateAdditiveOperator(MbcFraction a, MbcFraction b, Func<MbcInteger, MbcInteger, MbcInteger> fun)
        {
            var firstNumerator = new MbcInteger(a.Numerator * b.Denominator) { Sign = a.Sign };
            var secondNumerator = new MbcInteger(b.Numerator * a.Denominator) { Sign = b.Sign };

            var resultNumerator = fun(firstNumerator, secondNumerator);
            var resultDenominator = a.Denominator * b.Denominator;

            return new MbcFraction(resultNumerator, resultDenominator);
        }
    }
}