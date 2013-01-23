using NUnit.Framework;
using Mbc = MBC.Integer.MbcInteger;

namespace MBC.Tests.UnitTests.Integer
{
    [TestFixture, Category("UnitTest")]
    public class AdditiveOperatorTests : BaseTests
    {
        [Test, Combinatorial]
        public void TestOperatorAddittion_CheckInstanceOfResult_ShouldBeMbcIntegerInstance(
           [Values("1", "-1")] string a,
           [Values("1", "-1")]string b)
        {
            testIsInstanceOf<Mbc>(a, b, (x, y) => x + y);
        }

        [Test]
        [TestCase("1", "1", "2")]
        [TestCase("9", "12", "21")]
        public void TestOperatorAddittion_CalculateResultFirstAndSecondArePositive_ShouldBeEqualToExpected(
            string a, string b, string expected)
        {
            test<Mbc>(a, b, expected, (x, y) => x + y);
        }

        [Test]
        [TestCase("-1", "-1", "-2")]
        [TestCase("-9", "-12", "-21")]
        public void TestOperatorAddittion_CalculateResultFirstAndSecondAreNegative_ShouldBeEqualToExpected(
            string a, string b, string expected)
        {
            test<Mbc>(a, b, expected, (x, y) => x + y);
        }

        [Test]
        [TestCase("12", "-9", "3")]
        [TestCase("3", "-12", "-9")]
        public void TestOperatorAddittion_CalculateResultFirstIsPositiveAndSecondIsNegative_ShouldBeEqualToExpected(
            string a, string b, string expected)
        {
            test<Mbc>(a, b, expected, (x, y) => x + y);
        }

        [Test]
        [TestCase("-12", "9", "-3")]
        [TestCase("-9", "12", "3")]
        public void TestOperatorAddittion_CalculateResultFirstIsNegativeAndSecondIsPositive_ShouldBeEqualToExpected(
            string a, string b, string expected)
        {
            test<Mbc>(a, b, expected, (x, y) => x + y);
        }

        [Test, Combinatorial]
        public void TestOperatorSubtraction_CheckInstanceOfResult_ShouldBeMbcIntegerInstance(
           [Values("1", "-1")] string a,
           [Values("1", "-1")]string b)
        {
            testIsInstanceOf<Mbc>(a, b, (x, y) => x - y);
        }

        [Test]
        [TestCase("12", "9", "3")]
        [TestCase("9", "12", "-3")]
        public void TestOperatorSubtraction_CalculateResultFirstAndSecondArePositive_ShouldBeEqualToExpected(
            string a, string b, string expected)
        {
            test<Mbc>(a, b, expected, (x, y) => x - y);
        }

        [Test]
        [TestCase("-12", "-9", "-3")]
        [TestCase("-9", "-12", "3")]
        public void TestOperatorSubtraction_CalculateResultFirstAndSecondAreNegative_ShouldBeEqualToExpected(
            string a, string b, string expected)
        {
            test<Mbc>(a, b, expected, (x, y) => x - y);
        }

        [Test]
        [TestCase("12", "-9", "21")]
        [TestCase("9", "-12", "21")]
        public void TestOperatorSubtraction_CalculateResultFirstIsPositiveAndSecondIsNegative_ShouldBeEqualToExpected(
            string a, string b, string expected)
        {
            test<Mbc>(a, b, expected, (x, y) => x - y);
        }

        [Test]
        [TestCase("-12", "9", "-21")]
        [TestCase("-9", "12", "-21")]
        public void TestOperatorSubtraction_CalculateResultFirstIsNegativeAndSecondIsPositive_ShouldBeEqualToExpected(
            string a, string b, string expected)
        {
            test<Mbc>(a, b, expected, (x, y) => x - y);
        }
    }
}