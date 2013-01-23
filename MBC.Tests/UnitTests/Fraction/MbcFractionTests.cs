using System;
using MBC.Integer;
using MBC.UInteger;
using NUnit.Framework;
using Mbc = MBC.Fraction.MbcFraction;

namespace MBC.Tests.UnitTests.Fraction
{
    [TestFixture, Category("UnitTest")]
    public class MbcFractionTests
    {
        [Test]
        [TestCase("2/9")]
        [TestCase("-7/15")]
        public void TestConstructor_CorrectInitializationStrings_ShouldBeEqualToExpected(string expected)
        {
            var actual = (new Mbc(expected)).ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestConstructor_CorrectInitializationStringEmpty_ShouldBeEqualToExpected()
        {
            var expected = "";
            var actual = (new Mbc(expected)).ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("59", "15", MbcInteger.SignValue.Positive, "59/15")]
        [TestCase("45", "31", MbcInteger.SignValue.Negative, "-45/31")]
        public void TestConstructor_CorrectInitializationMbcUIntegerMbcUIntegerSignValue_ShouldBeEqualToExpected(
            string num, string den, MbcInteger.SignValue sign, string expected)
        {
            var numerator = new MbcUInteger(num);
            var denominator = new MbcUInteger(den);

            var actual = (new Mbc(numerator, denominator, sign)).ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("17", "36", "17/36")]
        [TestCase("-27", "195", "-27/195")]
        public void TestConstructor_CorrectInitializationMbcIntegerMbcUInteger_ShouldBeEqualToExpected(
            string num, string den, string expected)
        {
            var numerator = new MbcInteger(num);
            var denominator = new MbcUInteger(den);

            var actual = (new Mbc(numerator, denominator)).ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestConstructor_InvalidInitializationenominatorIsZero_ShouldBeThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(delegate { var a = new Mbc("4/0"); });
        }

        [Test]
        public void TestConstructor_InvalidInitializationenominatorStringWithMoreThenOneSlash_ShouldBeThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(delegate { var a = new Mbc("4/3/4"); });
        }
    }
}