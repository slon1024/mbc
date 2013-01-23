using MBC.UInteger;
using NUnit.Framework;

namespace MBC.Tests.UnitTests.UInteger
{
    [TestFixture, Category("UnitTest")]
    internal class RelationalOperatorTests : BaseTests
    {
        [Test]
        [TestCase("100", "10")]
        [TestCase("12345678123456781234567812345678", "1234567812345678")]
        [TestCase("12345678123456781234567812345678111", "12345678123456781234567812345678110")]
        public void TestOperatorGreater_AllCasesAreGreater_ShouldBeTrue(string a, string b)
        {
            var first = new MbcUInteger(a);
            var second = new MbcUInteger(b);

            Assert.That(first > second, Is.True);
        }

        [Test]
        [TestCase("10", "100")]
        [TestCase("1234567812345678", "12345678123456781234567812345678")]
        [TestCase("12345678123456781234567812345678", "12345678123456781234567812345698")]
        public void TestOperatorGreater_AllCasesAreLess_ShouldBeTrue(string a, string b)
        {
            var first = new MbcUInteger(a);
            var second = new MbcUInteger(b);

            Assert.That(first < second, Is.True);
        }

        [Test]
        [TestCase("100", "10")]
        [TestCase("12345678123456781234567812345678", "1234567812345678")]
        [TestCase("12345678123456781234567812345678111", "12345678123456781234567812345678110")]
        [TestCase("1234567890", "1234567890")]
        [TestCase("1234567890123", "1234567890123")]
        [TestCase("1234567890123456789012345678901234567890", "1234567890123456789012345678901234567890")]
        public void TestOperatorGreaterOrEqual_AllCasesAreGreaterOrEqual_ShouldBeTrue(string a, string b)
        {
            var first = new MbcUInteger(a);
            var second = new MbcUInteger(b);

            Assert.That(first >= second, Is.True);
        }

        [Test]
        [TestCase("10", "100")]
        [TestCase("1234567812345678", "12345678123456781234567812345678")]
        [TestCase("12345678123456781234567812345678", "12345678123456781234567812345698")]
        [TestCase("1234567890", "1234567890")]
        [TestCase("1234567890123", "1234567890123")]
        [TestCase("1234567890123456789012345678901234567890", "1234567890123456789012345678901234567890")]
        public void TestOperatorLessOrEqual_AllCasesAreLessOrEqual_ShouldBeTrue(string a, string b)
        {
            var first = new MbcUInteger(a);
            var second = new MbcUInteger(b);

            Assert.That(first <= second, Is.True);
        }
    }
}