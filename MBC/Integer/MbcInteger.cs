using System.Collections.Generic;
using MBC.UInteger;

namespace MBC.Integer
{
    public partial class MbcInteger : MbcUInteger
    {
        /// <summary>
        /// Sign: positive and negative.
        /// </summary>
        public enum SignValue
        {
            Positive,
            Negative
        }

        /// <summary>
        /// Sign of the number.
        /// Default is positive.
        /// </summary>
        private SignValue _sign = SignValue.Positive;

        /// <summary>
        /// Sign
        /// </summary>
        /// <see cref="_sign"/>
        public SignValue Sign
        {
            get { return _sign; }
            set { _sign = value; }
        }

        /// <summary>
        /// Set as a negative sign
        /// </summary>
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

        /// <summary>
        /// Is positive number?
        /// </summary>
        /// <see cref="SignValue"/>
        public bool IsPositive
        {
            get { return SignValue.Positive == Sign; }
        }

        /// <summary>
        /// Is negative number?
        /// </summary>
        /// <see cref="SignValue"/>
        public bool IsNegative
        {
            get { return SignValue.Negative == Sign; }
        }

        /// <summary>
        /// Cast the result as a string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            var result = base.ToString();

            if (IsPositive)
                return result;
            return "-" + result;
        }

        /// <summary>
        /// Cast to MbcUInteger
        /// </summary>
        /// <returns>MbcUInteger</returns>
        public MbcUInteger ToMbcUInteger()
        {
            var number = ToString();
            return new MbcUInteger('-' == number[0] ? number.Substring(1) : number);
        }
    }
}