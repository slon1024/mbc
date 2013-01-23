using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MBC.UInteger
{
    public partial class MbcUInteger
    {
        protected readonly List<uint> _integer = new List<uint>();
        private uint _length = 0;
        private readonly byte _lengthUInt = (byte)Math.Log10(uint.MaxValue);
        protected const char _firstChar = '1';
        protected bool _isFraction = false;

        public uint Length
        {
            get { return _length; }
        }

        public int Cell
        {
            get { return _integer.Count; }
        }

        public bool IsFraction
        {
            get { return _isFraction; }
        }

        #region Constructors

        public MbcUInteger(string number)
        {
            if (Regex.IsMatch(number, @"\D"))
                throw new ArgumentException(String.Format("String value '{0}' cannot be converted to a 'MbcUInteger'", number));

            if (string.IsNullOrEmpty(number))//equal null
                return;

            number = Regex.Replace(number, @"^0+", "");// 00001 -> 1
            if (String.Empty == number)// 0000 -> 0
                number = "0";

            var cell = (int)Math.Ceiling(number.Length / (double)_lengthUInt);
            if (cell > 1)
            {
                for (int i = 0; i < cell; i++)
                {
                    int start = i * _lengthUInt;
                    int length = (start + _lengthUInt < number.Length)
                                ? _lengthUInt
                                : number.Length - start;

                    Add(number.Substring(start, length));
                }
            }
            else
                Add(number);
        }

        public MbcUInteger(MbcUInteger number)
            : this(number.ToString())
        {
        }

        public MbcUInteger(int number)
            : this(number.ToString())
        {
        }

        public MbcUInteger(uint number)
            : this(number.ToString())
        {
        }

        public MbcUInteger(IEnumerable<int> number)
            : this(string.Join("", number))
        {
        }

        public MbcUInteger(IEnumerable<uint> number)
            : this(string.Join("", number))
        {
        }

        public MbcUInteger()
        {
        }

        #endregion Constructors

        private void Add(string value)
        {
            _integer.Add(uint.Parse(_firstChar + value));
            _length += (uint)value.Length;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            foreach (string tmp in _integer.Select(t => Convert.ToString(t)))
                str.Append(tmp.Substring(1));
            return str.ToString();
        }

        protected static int GetIntFromChar(char value)
        {
            return Convert.ToInt32(Convert.ToString(value));
        }

        private static int PrepareDigitValue(int value, ref int buffer)
        {
            const int baseDigit = 10;
            var level = (int)Math.Log10(Math.Abs(value));

            if (value > baseDigit - 1)
            {
                value -= baseDigit * level;
                buffer += level;
            }
            else if (value < 0)
            {
                level = 1;
                value += baseDigit * level;
                buffer = -1;
            }
            return value;
        }

        private static void Carry(ref int value, ref int buffer)
        {
            value += buffer;
            buffer = 0;

            if (value > 9)
            {
                buffer = value / 10;
                value -= buffer * 10;
            }
        }

        protected static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
    }
}