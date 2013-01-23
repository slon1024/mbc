using NUnit.Framework;
using Mbc = MBC.UInteger.MbcUInteger;

namespace MBC.Tests.UnitTests.UInteger
{
    [TestFixture, Category("UnitTest")]
    internal class AdditiveOperatorTests : BaseTests
    {
        [Test]
        [TestCase("1", "1", "2")]
        [TestCase("1", "2", "3")]
        [TestCase("2", "1", "3")]
        [TestCase("120", "23", "143")]
        [TestCase("99", "1", "100")]
        public void TestOperatorAddittion_CalculateResult_ShouldBeEqualToExpected(
            string a, string b, string expected)
        {
            test<Mbc>(a, b, expected, (x, y) => x + y);
        }

        [Test]
        [TestCase("1", "1", "0")]
        [TestCase("123456789012345", "123456789012345", "0")]
        [TestCase("2", "1", "1")]
        [TestCase("100", "1", "99")]
        [TestCase("123456789012345123456789012345", "92384345998347399", "123456789012252739110790664946")]
        public void TestOperatorSubtraction_CalculateResult_ShouldBeEqualToExpected(
            string a, string b, string expected)
        {
            test<Mbc>(a, b, expected, (x, y) => x - y);
        }

        [Test]
        [TestCase("0", "1")]
        public void TestOperatorSubtraction_CheckBorderCase_ShouldBeNull(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);
            var actual = (first - second);

            Assert.That(actual, Is.Null);
        }
    }
}