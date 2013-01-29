namespace MBC.UInteger
{
    /// <summary>
    /// Implementation of relational operators for MbcUInteger:
    ///  - greater
    ///  - less
    ///  - graterOrEqual
    ///  - lessOrEqual
    ///  </summary>
    public partial class MbcUInteger
    {
        /// <summary>
        ///  Gerater operator
        /// </summary>
        /// <see cref="MbcUInteger.IsGreater"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator >(MbcUInteger a, MbcUInteger b)
        {
            return IsGreater(a, b);
        }

        /// <summary>
        /// Gerater operator
        /// First argument is a string.
        /// </summary>
        /// <see cref="MbcUInteger.IsGreater"/>
        /// <param name="a">string - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator >(string a, MbcUInteger b)
        {
            return IsGreater(new MbcUInteger(a), b);
        }

        /// <summary>
        /// Gerater operator
        /// Second argument is a string.
        /// </summary>
        /// <see cref="MbcUInteger.IsGreater"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">string - second number</param>
        /// <returns>bool</returns>
        public static bool operator >(MbcUInteger a, string b)
        {
            return IsGreater(a, new MbcUInteger(b));
        }

        /// <summary>
        /// Less operator
        /// </summary>
        /// <see cref="MbcUInteger.IsLess"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator <(MbcUInteger a, MbcUInteger b)
        {
            return IsLess(a, b);
        }

        /// <summary>
        /// Less operator
        /// First argument is a string.
        /// </summary>
        /// <see cref="MbcUInteger.IsLess"/>
        /// <param name="a">string - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator <(string a, MbcUInteger b)
        {
            return IsLess(new MbcUInteger(a), b);
        }

        /// <summary>
        /// Less operator
        /// Second argument is a string.
        /// </summary>
        /// <see cref="MbcUInteger.IsLess"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">string - second number</param>
        /// <returns>bool</returns>
        public static bool operator <(MbcUInteger a, string b)
        {
            return IsLess(a, new MbcUInteger(b));
        }

        /// <summary>
        ///  Gerater or equal operator
        /// </summary>
        /// <see cref="MbcUInteger.IsGreaterOrEqual"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator >=(MbcUInteger a, MbcUInteger b)
        {
            return IsGreaterOrEqual(a, b);
        }

        /// <summary>
        ///  Less or equal operator
        /// </summary>
        /// <see cref="MbcUInteger.IsLessOrEqual"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator <=(MbcUInteger a, MbcUInteger b)
        {
            return IsLessOrEqual(a, b);
        }

        /// <summary>
        /// Implementation of the comparison and the first number is greater than the second number
        /// </summary>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        protected static bool IsGreater(MbcUInteger a, MbcUInteger b)
        {
            if (a.Length < b.Length)
                return false;

            if (a.Length > b._length || a.Cell < 1)
                return true;

            if (a._integer.Count > 1)
            {
                for (int i = 0; i < a.Cell; i++)
                    if (a._integer[i] < b._integer[i])
                        return false;
            }

            return a._integer[a.Cell - 1] > b._integer[a.Cell - 1];
        }

        /// <summary>
        /// Implementation of the comparison and the first number is greater than or equal to the second number. 
        /// It is based on logical operations: isEqual and isGreater.
        /// </summary>
        /// <see cref="MbcUInteger.IsEqual"/>
        /// <seealso cref="MbcUInteger.IsGreater"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        protected static bool IsGreaterOrEqual(MbcUInteger a, MbcUInteger b)
        {
            return IsEqual(a, b) || IsGreater(a, b);
        }

        /// <summary>
        /// Implementation of the comparison and the first number is less the second number. 
        /// It is based on logical operations: isEqual and isGreater.
        /// </summary>
        /// <see cref="MbcUInteger.IsEqual"/>
        /// <seealso cref="MbcUInteger.IsGreater"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        protected static bool IsLess(MbcUInteger a, MbcUInteger b)
        {
            return false == (IsEqual(a, b) || IsGreater(a, b));
        }

        /// <summary>
        /// Implementation of the comparison and the first number is less than or equal to the second number. 
        /// It is based on logical operations: isEqual and isGreater.
        /// </summary>
        /// <see cref="MbcUInteger.IsEqual"/>
        /// <seealso cref="MbcUInteger.IsGreater"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        protected static bool IsLessOrEqual(MbcUInteger a, MbcUInteger b)
        {
            return IsEqual(a, b) || false == IsGreater(a, b);
        }
    }
}