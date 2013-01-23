using NUnit.Framework;
using Mbc = MBC.Fraction.MbcFraction;

namespace MBC.Tests.UnitTests.Fraction
{
    [TestFixture, Category("UnitTest")]
    public class EqualityOperatorTests
    {
        [Test]
        [TestCase("5/12", "5/12")]
        [TestCase("5/1", "5")]
        public void TestOperatorEquality_AllCasesAreEquals_ShouldBeTrue(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first == second, Is.True);
        }

        [Test]
        [TestCase("5/12", "12/5")]
        [TestCase("5", "12")]
        public void TestOperatorEquality_AllCasesAreNotEquals_ShouldBeFalse(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first == second, Is.False);
        }

        [Test]
        [TestCase("5/12", "12/5")]
        [TestCase("5", "12")]
        public void TestOperatorInequality_AllCasesAreNotEquals_ShouldBeTrue(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first != second, Is.True);
        }

        [Test]
        [TestCase("5/12", "5/12")]
        [TestCase("5/1", "5")]
        public void TestOperatorInequality_AllCasesAreEquals_ShouldBeFalse(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first != second, Is.False);
        }
    }
}