using System;
using MBC.Integer;
using MBC.UInteger;

namespace MBC.Fraction
{
    //TODO doSimpleFraction()

    public partial class MbcFraction : MbcInteger
    {
        public MbcUInteger Numerator { get; private set; }

        public MbcUInteger Denominator { get; private set; }

        public MbcFraction(string number)
        {
            if (string.IsNullOrEmpty(number))
                return;
            //throw new ArgumentException(String.Format("Value '{0}' cannot be null or empty", number));

            var fration = number.Split(new[] { '/' });
            if (fration.Length > 2)
                throw new ArgumentException(String.Format("Value '{0}' has two or more slash and can not be converted to 'MbcFraction'", number));

            var numerator = new MbcInteger(fration[0]);
            var denominator = new MbcUInteger(fration.Length == 2 ? fration[1] : "1");

            if (denominator.ToString() == "0")
                throw new ArgumentException("denominator cannot be zero");

            Numerator = numerator.ToMbcUInteger();
            Denominator = denominator;
            Sign = numerator.Sign;
        }

        public MbcFraction(MbcUInteger numerator, MbcUInteger denominator, SignValue sign = SignValue.Positive) :
            this(String.Format("{0}{1}/{2}", (sign == SignValue.Positive) ? "" : "-", numerator, denominator))
        {
        }

        public MbcFraction(MbcInteger numerator, MbcUInteger denominator)
            : this(numerator.ToMbcUInteger(), denominator, numerator.Sign)
        {
        }

        public override string ToString()
        {
            var signChar = (IsPositive) ? "" : "-";
            var result = String.Format("{0}{1}/{2}", signChar, Numerator, Denominator);

            return ("/" == result) ? "" : result;
        }
    }
}