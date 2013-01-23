using NUnit.Framework;
using Mbc = MBC.Integer.MbcInteger;

namespace MBC.Tests.UnitTests.Integer
{
    [TestFixture, Category("UnitTest")]
    public class RelationalOperatorTests
    {
        [Test, Sequential]
        public void TestOperatorGreater_AllCasesAreLess_ShouldBeTrue(
            [Values("100", "10")] string a,
            [Values("-10", "-100")] string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first > second, Is.True);
        }

        [Test, Sequential]
        public void TestOperatorGreater_AllCasesAreLess_ShouldBeFalse(
            [Values("0", "-1", "-100")] string a,
            [Values("0", "-1", "10")] string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first > second, Is.False);
        }

        [Test, Sequential]
        public void TestOperatorLess_AllCasesAreLess_ShouldBeTrue(
            [Values("1", "-1", "-10")] string a,
            [Values("10", "10", "-1")] string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first < second, Is.True);
        }

        [Test, Sequential]
        public void TestOperatorLess_AllCasesAreGrater_ShouldBeFalse(
            [Values("10", "10", "-1")] string a,
            [Values("1", "-1", "-10")] string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first < second, Is.False);
        }

        [Test, Sequential]
        public void TestOperatorGreaterOrEqual_AllCasesGreaterOrEqual_ShouldBeTrue(
            [Values("0", "-1", "1", "100")] string a,
            [Values("0", "-1", "-1", "1")] string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first >= second, Is.True);
        }

        [Test, Sequential]
        public void TestOperatorLessOrEqual_AllCasesLessOrEqual_ShouldBeTrue(
            [Values("0", "1", "-1")] string a,
            [Values("0", "8", "7")] string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first <= second, Is.True);
        }
    }
}