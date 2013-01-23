using MBC.Integer;
using NUnit.Framework;

namespace MBC.Tests.UnitTests.Integer
{
    [TestFixture, Category("UnitTest")]
    public class MultiplicativeOperatorTests : BaseTests
    {
        [Test, Combinatorial]
        public void TestOperatorMultiplication_CheckInstanceOfResult_ShouldBeMbcIntegerInstance(
           [Values("1", "-1")] string a,
           [Values("1", "-1")]string b)
        {
            testIsInstanceOf<MbcInteger>(a, b, (x, y) => x * y);
        }

        [Test, Sequential]
        public void TestOperatorMultiplication_CheckCalculationResult_ShouldBeEqualToExpected(
            [Values("8", "-7", "6", "-4")] string a,
            [Values("2", "-2", "-2", "7")] string b,
            [Values("16", "14", "-12", "-28")] string expected)
        {
            test<MbcInteger>(a, b, expected, (x, y) => x * y);
        }

        [Test, Combinatorial]
        public void TestOperatorDivision_CheckInstanceOfResult_ShouldBeMbcIntegerInstance(
           [Values("1", "-1")] string a,
           [Values("1", "-1")]string b)
        {
            testIsInstanceOf<MbcInteger>(a, b, (x, y) => x / y);
        }

        [Test, Sequential]
        public void TestOperatorDivision_CheckCalculationResult_ShouldBeEqualToExpected(
            [Values("10", "-12", "15", "-20", "5")] string a,
            [Values("2", "-2", "-3", "5", "10")] string b,
            [Values("5", "6", "-5", "-4", "0")] string expected)
        {
            test<MbcInteger>(a, b, expected, (x, y) => x / y);
        }

        [Test, Combinatorial]
        public void TestOperatorModulo_CheckInstanceOfResult_ShouldBeMbcIntegerInstance(
           [Values("1", "-1")] string a,
           [Values("1", "-1")]string b)
        {
            testIsInstanceOf<MbcInteger>(a, b, (x, y) => x % y);
        }

        [Test]
        [TestCase("8", "3", "2")]
        [TestCase("-8", "-3", "-2")]
        [TestCase("-8", "3", "1")]
        [TestCase("8", "-3", "-1")]
        public void TestOperatorModulo_CheckCalculationResult_ShouldBeEqualToExpected(string a, string b, string expected)
        {
            test<MbcInteger>(a, b, expected, (x, y) => x % y);
        }
    }
}