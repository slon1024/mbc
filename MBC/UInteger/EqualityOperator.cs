namespace MBC.UInteger
{
    /// <summary>
    /// Implementation of equality and inequality operators for MbcUInteger.
    /// </summary>
    public partial class MbcUInteger
    {
        /// <summary>
        /// Equality operator
        /// </summary>
        /// <see cref="MbcUInteger.IsEqual"/>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator ==(MbcUInteger a, MbcUInteger b)
        {
            return IsEqual(a, b);
        }

        /// <summary>
        /// Inequality operator
        /// Implementation based on a logical negation equality operator 
        /// </summary>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator !=(MbcUInteger a, MbcUInteger b)
        {
            return false == (a == b);
        }

        /// <summary>
        /// Implementation of comparison
        /// </summary>
        /// <param name="a">MbcUInteger - first number</param>
        /// <param name="b">MbcUInteger - second number</param>
        /// <returns>bool</returns>
        protected static bool IsEqual(MbcUInteger a, MbcUInteger b)
        {
            if (a.Length != b.Length)
                return false;

            for (var i = 0; i < a._integer.Count; i++)
                if (a._integer[i] != b._integer[i])
                    return false;

            return true;
        }

        /// <summary>
        /// Compare whether the objects are equal.
        /// Standard method overloading.
        /// </summary>
        /// <param name="obj">object that needs to be compared</param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            var number = obj as MbcUInteger;
            if (null == number)
                return false;

            return this == number;
        }

        /// <summary>
        /// Ovveride GetHashCode
        /// </summary>
        /// <returns>int - hash code</returns>
        public override int GetHashCode()
        {
            return _integer.GetHashCode();
        }
    }
}