using NUnit.Framework;
using Mbc = MBC.Fraction.MbcFraction;

namespace MBC.Tests.UnitTests.Fraction
{
    [TestFixture, Category("UnitTest")]
    public class RelationalOperatorTests
    {
        [Test, Sequential]
        public void TestOperatorGreater_AllCasesAreGreater_ShouldBeTrue(
            [Values("15/8", "19/7", "-12/198")] string a,
            [Values("15/37", "-18/11", "-12/234")] string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first > second, Is.True);
        }

        [Test, Sequential]
        public void TestOperatorLess_AllCasesAreLess_ShouldBeTrue(
            [Values("15/37", "-18/11", "-12/234")] string a,
            [Values("15/8", "19/7", "-12/198")] string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first < second, Is.True);
        }

        [Test, Sequential]
        public void TestOperatorGreater_AllCasesAreLess_ShouldBeFalse(
            [Values("15/37", "18/11")] string a,
            [Values("15/8", "19/7")] string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first > second, Is.False);
        }

        [Test, Sequential]
        public void TestOperatorLess_AllCasesAreGreater_ShouldBeFalse(
            [Values("15/8", "19/7")] string a,
            [Values("15/37", "18/11")] string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first < second, Is.False);
        }

        [Test, Sequential]
        public void TestOperatorGreaterOrEqual_AllCasesGreaterOrEqual_ShouldBeTrue(
            [Values("15/8", "19/7", "17/6", "-34/15")] string a,
            [Values("15/37", "18/11", "17/6", "-34/15")] string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first >= second, Is.True);
        }

        [Test, Sequential]
        public void TestOperatorLessOrEqual_AllCasesLessOrEqual_ShouldBeTrue(
            [Values("15/37", "18/11", "17/6", "-34/15")] string a,
            [Values("15/8", "19/7", "17/6", "-34/15")] string b)
        {
            var first = new Mbc(a);
            var second = new Mbc(b);

            Assert.That(first <= second, Is.True);
        }
    }
}