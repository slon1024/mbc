using System.Collections.Generic;
using MBC.UInteger;

namespace MBC.Integer
{
    public partial class MbcInteger : MbcUInteger
    {
        public enum SignValue
        {
            Negative,
            Positive
        }

        private SignValue _sign = SignValue.Positive;

        public SignValue Sign
        {
            get { return _sign; }
            set { _sign = value; }
        }

        public void SetNegative()
        {
            _sign = SignValue.Negative;
        }

        #region Constructors

        public MbcInteger(string number)
            : base(('-' == number[0] ? number.Substring(1) : number))
        {
            if ('-' == number[0])
                SetNegative();
        }

        public MbcInteger(int number)
            : this(number.ToString())
        {
        }

        public MbcInteger(MbcUInteger number)
            : this(number.ToString())
        {
        }

        public MbcInteger(MbcInteger number)
            : this(number.ToString())
        {
        }

        public MbcInteger(uint number)
            : this(number.ToString())
        {
        }

        public MbcInteger(IEnumerable<uint> number)
            : this(string.Join("", number))
        {
        }

        public MbcInteger()
        {
        }

        #endregion Constructors

        public bool IsPositive
        {
            get { return SignValue.Positive == Sign; }
        }

        public bool IsNegative
        {
            get { return SignValue.Negative == Sign; }
        }

        public override string ToString()
        {
            var result = base.ToString();

            if (IsPositive)
                return result;
            return "-" + result;
        }

        public MbcUInteger ToMbcUInteger()
        {
            //TODO optimalize: return (MbcUInteger) this;

            var number = ToString();
            return new MbcUInteger('-' == number[0] ? number.Substring(1) : number);
        }
    }
}