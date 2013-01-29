using MBC.UInteger;

namespace MBC.Integer
{
    /// <summary>
    /// Implementation of relational operators for MbcInteger:
    ///  - greater
    ///  - less
    ///  - graterOrEqual
    ///  - lessOrEqual
    ///  </summary>
    public partial class MbcInteger
    {
        /// <summary>
        ///  Gerater operator
        /// </summary>
        /// <see cref="MbcInteger.IsGreater"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator >(MbcInteger a, MbcInteger b)
        {
            return IsGreater(a, b);
        }

        /// <summary>
        ///  Less operator
        /// </summary>
        /// <see cref="MbcInteger.IsLess"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator <(MbcInteger a, MbcInteger b)
        {
            return IsLess(a, b);
        }

        /// <summary>
        ///  Gerater or equal operator
        /// </summary>
        /// <see cref="MbcInteger.IsGreaterOrEqual"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator >=(MbcInteger a, MbcInteger b)
        {
            return IsGreaterOrEqual(a, b);
        }

        /// <summary>
        ///  Less or equal operator
        /// </summary>
        /// <see cref="MbcInteger.IsLessOrEqual"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator <=(MbcInteger a, MbcInteger b)
        {
            return IsLessOrEqual(a, b);
        }

        /// <summary>
        ///  Implementation of the first number is greater than the second number
        /// </summary>
        /// <see cref="MbcUInteger.IsGreater"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>bool</returns>
        protected static bool IsGreater(MbcInteger a, MbcInteger b)
        {
            if (a.IsNegative && b.IsPositive)
                return false;
            if (a.IsPositive && b.IsNegative)
                return true;
            if (a.IsNegative && b.IsNegative)
                return IsGreater(b.ToMbcUInteger(), a.ToMbcUInteger());//swap (a, b) -> (b, a)

            return IsGreater(a.ToMbcUInteger(), b.ToMbcUInteger());
        }

        /// <summary>
        ///  Implementation of the first number is less than the second number
        /// </summary>
        /// <see cref="MbcUInteger.IsLess"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>bool</returns>
        protected static bool IsLess(MbcInteger a, MbcInteger b)
        {
            if (a.IsNegative && b.IsPositive)
                return true;
            if (a.IsPositive && b.IsNegative)
                return false;
            if (a.IsNegative && b.IsNegative)
                return IsLess(b.ToMbcUInteger(), a.ToMbcUInteger());//swap (a, b) -> (b, a)

            return IsLess(a.ToMbcUInteger(), b.ToMbcUInteger());
        }

        /// <summary>
        ///  Implementation of the first number is greater or equal than the second number
        /// </summary>
        /// <see cref="MbcUInteger.IsEqual"/>
        /// <see cref="MbcUInteger.IsGreater"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>bool</returns>
        protected static bool IsGreaterOrEqual(MbcInteger a, MbcInteger b)
        {
            return IsEqual(a, b) || IsGreater(a, b);
        }

        /// <summary>
        ///  Implementation of the first number is greater or equal than the second number
        /// </summary>
        /// <see cref="MbcUInteger.IsEqual"/>
        /// <see cref="MbcUInteger.IsGreater"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>bool</returns>
        protected static bool IsLessOrEqual(MbcInteger a, MbcInteger b)
        {
            return IsEqual(a, b) || false == IsGreater(a, b);
        }
    }
}