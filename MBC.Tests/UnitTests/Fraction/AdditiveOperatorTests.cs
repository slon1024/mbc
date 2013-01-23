using MBC.Fraction;
using NUnit.Framework;

namespace MBC.Tests.UnitTests.Fraction
{
    [TestFixture, Category("UnitTest")]
    public class AdditiveOperatorTests : BaseTests
    {
        [Test, Combinatorial]
        public void TestOperatorAddittion_CheckInstanceOfResult_ShouldBeMbcFractionInstance(
           [Values("1/2", "-1/3")] string a,
           [Values("1/7", "-1/5")]string b)
        {
            testIsInstanceOf<MbcFraction>(a, b, (x, y) => x + y);
        }

        [Test]
        [TestCase("1/3", "1/8", "11/24")]
        [TestCase("-1/3", "-1/8", "-11/24")]
        [TestCase("-1/3", "1/8", "-5/24")]
        [TestCase("-1/8", "1/3", "5/24")]
        [TestCase("1/3", "-1/8", "5/24")]
        [TestCase("1/8", "-1/3", "-5/24")]
        public void TestOperatorAddittion_CalculateResult_ShouldBeEqualToExpected(string a, string b, string expected)
        {
            test<MbcFraction>(a, b, expected, (x, y) => x + y);
        }

        [Test, Combinatorial]
        public void TestOperatorSubtraction_CheckInstanceOfResult_ShouldBeMbcFractionInstance(
           [Values("1/2", "-1/3")] string a,
           [Values("1/7", "-1/5")]string b)
        {
            testIsInstanceOf<MbcFraction>(a, b, (x, y) => x - y);
        }

        [Test]
        [TestCase("1/3", "1/8", "5/24")]
        [TestCase("-1/3", "-1/8", "-5/24")]
        public void TestOperatorSubtraction_CalculateResult_ShouldBeEqualToExpected(string a, string b, string expected)
        {
            test<MbcFraction>(a, b, expected, (x, y) => x - y);
        }
    }
}