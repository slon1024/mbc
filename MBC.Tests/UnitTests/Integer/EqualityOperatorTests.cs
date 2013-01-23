using NUnit.Framework;
using Mbc = MBC.Integer.MbcInteger;

namespace MBC.Tests.UnitTests.Integer
{
    [TestFixture, Category("UnitTest")]
    public class EqualityOperatorTests
    {
        [Test]
        [TestCase("0", "0")]
        [TestCase("125", "125")]
        [TestCase("-133", "-133")]
        public void TestOperatorEquality_AllCasesAreEquals_ShouldBeTrue(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first == second, Is.True);
        }

        [Test]
        [TestCase("0", "2")]
        [TestCase("125", "-125")]
        [TestCase("-1", "1")]
        public void TestOperatorEquality_AllCasesAreNotEquals_ShouldBeFalse(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first == second, Is.False);
        }

        [Test]
        [TestCase("0", "2")]
        [TestCase("125", "-125")]
        [TestCase("-1", "1")]
        public void TestOperatorInequality_AllCasesAreNotEquals_ShouldBeTrue(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first != second, Is.True);
        }

        [Test]
        [TestCase("0", "0")]
        [TestCase("125", "125")]
        [TestCase("-133", "-133")]
        public void TestOperatorInequality_AllCasesAreEquals_ShouldBeFalse(string a, string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first != second, Is.False);
        }
    }
}