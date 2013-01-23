using NUnit.Framework;
using Mbc = MBC.UInteger.MbcUInteger;

namespace MBC.Tests.UnitTests.UInteger
{
    [TestFixture, Category("UnitTest")]
    internal class EqualityOperatorTests
    {
        [Test]
        [TestCase("0", "0")]
        [TestCase("1234567890", "1234567890")]
        [TestCase("1234567890123", "1234567890123")]
        [TestCase("1234567890123456789012345678901234567890", "1234567890123456789012345678901234567890")]
        public void TestOperatorEquality_AllCasesAreEquals_ShouldBeTrue(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first == second, Is.True);
        }

        [Test]
        [TestCase("0", "1")]
        [TestCase("12345678901234567890", "123456789")]
        [TestCase("1234567890123", "1234567890133")]
        [TestCase("1234567890123456789012345678901232567890", "1234567890123456789012345678901234567890")]
        public void TestOperatorEquality_AllCasesAreNotEquals_ShouldBeFalse(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first == second, Is.False);
        }

        [Test]
        [TestCase("0", "1")]
        [TestCase("12345678901234567890", "123456789")]
        [TestCase("1234567890123", "1234567890133")]
        [TestCase("1234567890123456789012345678901232567890", "1234567890123456789012345678901234567890")]
        public void TestOperatorInequality_AllCasesAreNotEquals_ShouldBeTrue(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first != second, Is.True);
        }

        [Test]
        [TestCase("0", "0")]
        [TestCase("1234567890", "1234567890")]
        [TestCase("1234567890123", "1234567890123")]
        [TestCase("1234567890123456789012345678901234567890", "1234567890123456789012345678901234567890")]
        public void TestOperatorInequality_AllCasesAreEquals_ShouldBeFalse(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first != second, Is.False);
        }
    }
}