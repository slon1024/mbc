using System;
using MBC.UInteger;
using NUnit.Framework;
using Mbc = MBC.Integer.MbcInteger;

namespace MBC.Tests.UnitTests.Integer
{
    [TestFixture, Category("UnitTest")]
    public class MbcIntegerTests
    {
        [Test, Sequential]
        public void TestConstructor_CorrectInitializationIntegers_ShouldBeEqualToExpected(
            [Values(int.MaxValue, 0, int.MinValue)] int number)
        {
            var actual = (new Mbc(number)).ToString();
            var expected = number.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Sequential]
        public void TestConstructor_InvalidInitializationStrings_ShouldBeArgumentException(
            [Values("abc", "0aa", "-12z", "--1")] string number)
        {
            Assert.Throws<ArgumentException>(delegate { var a = new Mbc(number); });
        }

        [Test]
        public void TestConstructor_CorrectInitializationMbcInteger_ShouldBeEqualToExpected()
        {
            var number = new Mbc(10);

            var actual = new Mbc(number).ToString();
            var expected = number.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Sequential]
        public void TestConvertToMbcUInteger_AnalyzePositiveAndNegativeCases_ShouldBeEqualToExpected(
            [Values("0", "357", "-456")] string number)
        {
            var actual = (new Mbc(number).ToMbcUInteger()).ToString();
            var expected = (new MbcUInteger('-' == number[0] ? number.Substring(1) : number)).ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Sequential]
        public void TestConvertToString_AnalyzePositiveAndNegativeCases_ShouldBeEqualToExpected(
            [Values("0", "357", "-456")] string expected)
        {
            var actual = (new Mbc(expected)).ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}