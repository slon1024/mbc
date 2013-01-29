using MBC.UInteger;

namespace MBC.Integer
{
    /// <summary>
    /// Implementation of equality and inequality operators for MbcInteger.
    /// </summary>
    public partial class MbcInteger
    {
        /// <summary>
        /// Equality operator
        /// </summary>
        /// <see cref="MbcUInteger.IsEqual"/>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator ==(MbcInteger a, MbcInteger b)
        {
            return a.Sign == b.Sign && IsEqual(a, b);
        }

        /// <summary>
        /// Inequality operator
        /// Implementation based on a logical negation equality operator 
        /// </summary>
        /// <param name="a">MbcInteger - first number</param>
        /// <param name="b">MbcInteger - second number</param>
        /// <returns>bool</returns>
        public static bool operator !=(MbcInteger a, MbcInteger b)
        {
            return false == (a == b);
        }

        /// <summary>
        /// Compare whether the objects are equal.
        /// Standard method overloading.
        /// </summary>
        /// <param name="obj">object that needs to be compared</param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            var number = obj as MbcInteger;
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