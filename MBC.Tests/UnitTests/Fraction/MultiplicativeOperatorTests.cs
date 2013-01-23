using MBC.Fraction;
using NUnit.Framework;

namespace MBC.Tests.UnitTests.Fraction
{
    [TestFixture, Category("UnitTest")]
    public class MultiplicativeOperatorTests : BaseTests
    {
        [Test, Combinatorial]
        public void TestOperatorMultiplication_CheckInstanceOfResult_ShouldBeMbcFractionInstance(
           [Values("1/5", "-1/5")] string a,
           [Values("1/5", "-1/5")]string b)
        {
            testIsInstanceOf<MbcFraction>(a, b, (x, y) => x * y);
        }

        [Test, Sequential]
        public void TestOperatorMultiplication_CheckCalculationResult_ShouldBeEqualToExpected(
            [Values("3/7", "-3/7", "-3/7", "3/7")] string a,
            [Values("7/8", "-7/8", "7/8", "-7/8")] string b,
            [Values("21/56", "21/56", "-21/56", "-21/56")] string expected)
        {
            test<MbcFraction>(a, b, expected, (x, y) => x * y);
        }

        [Test, Combinatorial]
        public void TestOperatorDivision_CheckInstanceOfResult_ShouldBeMbcFractionInstance(
           [Values("1/3", "-1/3")] string a,
           [Values("1/3", "-1/3")]string b)
        {
            testIsInstanceOf<MbcFraction>(a, b, (x, y) => x / y);
        }

        [Test]
        [TestCase("3/7", "7/8", "24/49")]
        [TestCase("3/7", "7/8", "24/49")]
        [TestCase("-3/7", "-7/8", "24/49")]
        [TestCase("-3/7", "7/8", "-24/49")]
        [TestCase("3/7", "-7/8", "-24/49")]
        public void TestOperatorDivision_CheckCalculationResult_ShouldBeEqualToExpected(
            string a,
            string b,
            string expected)
        {
            test<MbcFraction>(a, b, expected, (x, y) => x / y);
        }
    }
}