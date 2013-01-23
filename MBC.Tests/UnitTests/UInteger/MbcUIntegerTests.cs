using System;
using System.Collections.Generic;
using NUnit.Framework;
using Mbc = MBC.UInteger.MbcUInteger;

namespace MBC.Tests.UnitTests.UInteger
{
    [TestFixture, Category("UnitTest")]
    public class MbcUIntegerTests
    {
        [Test, Sequential]
        public void TestConstructor_CorrectInitializationIntegers_ShouldBeEqualToExpected(
            [Values(0, 123456, int.MaxValue / 2, int.MaxValue)] int number)
        {
            var actual = (new Mbc(number)).ToString();
            var expected = number.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Sequential]
        public void TestConstructor_CorrectInitializationUnsignedIntegers_ShouldBeEqualToExpected(
            [Values(uint.MinValue, 100U, uint.MaxValue)] uint number)
        {
            var actual = (new Mbc(number)).ToString();
            var expected = number.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestConstructor_CorrectInitializationUnsignedIEnumerableUints_ShouldBeEqualToExpected()
        {
            var number = new List<uint> { 1, 2, 3, 4, 5 };

            var actual = new Mbc(number).ToString();
            var expected = string.Join("", number);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Sequential]
        public void TestConstructor_CorrectInitializationStrings_ShouldBeEqualToExpected(
            [Values("", "0", "12345678", "1234567890123456789012345678901234567890")] string expected)
        {
            var actual = (new Mbc(expected)).ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Sequential]
        public void TestConstructor_InvalidInitializationStrings_ShouldBeArgumentException(
            [Values("-1", "a", "1111 ", "111a1")] string number)
        {
            Assert.Throws<ArgumentException>(delegate { var a = new Mbc(number); });
        }

        [Test, Sequential]
        public void TestConstructor_AnalyzeInputWithZero_ShouldDeleteAllZerosAtTheBegin(
            [Values("0", "00", "100", "0000000000100")] string a,
            [Values("0", "0", "100", "100")] string expected)
        {
            var actual = (new Mbc(a)).ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestIsFration_CheckValue_ShouldBeFalse()
        {
            var number = new Mbc("1");

            Assert.That(number.IsFraction, Is.False);
        }
    }
}