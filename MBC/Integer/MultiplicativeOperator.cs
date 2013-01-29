using MBC.UInteger;

namespace MBC.Integer
{
    /// <summary>
    /// Implementation of multiplication, division and modulo operators for MbcUInteger.
    /// </summary>
    public partial class MbcInteger
    {
        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <see cref="MbcInteger.CalcuateMultiplication"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>MbcInteger</returns>
        public static MbcInteger operator *(MbcInteger a, MbcInteger b)
        {
            return CalcuateMultiplication(a, b);
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <see cref="MbcInteger.CalcuateDivision"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>MbcInteger</returns>
        public static MbcInteger operator /(MbcInteger a, MbcInteger b)
        {
            return CalcuateDivision(a, b);
        }

        /// <summary>
        /// Modulo operator.
        /// </summary>
        /// <see cref="MbcInteger.CalcuateModulo"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>MbcInteger</returns>
        public static MbcInteger operator %(MbcInteger a, MbcInteger b)
        {
            return CalcuateModulo(a, b);
        }

        /// <summary>
        /// Implementation of multiplication.
        /// </summary>
        /// <see cref="MbcUInteger.CalcuateMultiplication"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>MbcInteger</returns>
        protected static MbcInteger CalcuateMultiplication(MbcInteger a, MbcInteger b)
        {
            var sign = SignValue.Positive;
            if ((a.IsPositive && b.IsNegative) || (a.IsNegative && b.IsPositive))
                sign = SignValue.Negative;

            return new MbcInteger(CalcuateMultiplication(a.ToMbcUInteger(), b.ToMbcUInteger())) { _sign = sign };
        }

        /// <summary>
        /// Implementation of division.
        /// </summary>
        /// <see cref="MbcUInteger.CalcuateDivision"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>MbcInteger</returns>
        protected static MbcInteger CalcuateDivision(MbcInteger a, MbcInteger b)
        {
            var sign = SignValue.Positive;
            if ((a.IsPositive && b.IsNegative) || (a.IsNegative && b.IsPositive))
                sign = SignValue.Negative;

            return new MbcInteger(CalcuateDivision(a.ToMbcUInteger(), b.ToMbcUInteger())) { _sign = sign };
        }

        /// <summary>
        /// Implementation of modulo.
        /// </summary>
        /// <see cref="MbcUInteger.CalcuateModulo"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>MbcInteger</returns>
        protected static MbcInteger CalcuateModulo(MbcInteger a, MbcInteger b)
        {
            if ((a.IsPositive && b.IsPositive) || (a.IsNegative && b.IsNegative))
                return new MbcInteger(CalcuateModulo(a.ToMbcUInteger(), b.ToMbcUInteger())) { _sign = a.Sign };

            var quotient = new MbcInteger(a.ToMbcUInteger() / b.ToMbcUInteger()) + new MbcInteger("1");
            var rest = a + (quotient * b);

            return new MbcInteger(rest);
        }
    }
}