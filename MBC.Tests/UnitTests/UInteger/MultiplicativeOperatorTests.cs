using MBC.UInteger;
using NUnit.Framework;

namespace MBC.Tests.UnitTests.UInteger
{
    [TestFixture, Category("UnitTest")]
    public class MultiplicativeOperatorTests : BaseTests
    {
        [Test]
        [TestCase("0", "10", "0")]
        [TestCase("34355", "0", "0")]
        [TestCase("1", "10", "10")]
        [TestCase("12323", "1", "12323")]
        public void TestOperatorMultiplication_CalculateBorderCases_ShouldBeEqualToExpected(string a, string b, string expected)
        {
            test<MbcUInteger>(a, b, expected, (x, y) => x * y);
        }

        [Test]
        [TestCase("2", "111", "222")]
        [TestCase("111111111", "111111111", "12345678987654321")]
        [TestCase("99", "999", "98901")]
        [TestCase("999999", "999", "998999001")]
        [TestCase("15", "3587", "53805")]
        [TestCase("9", "9999999999", "89999999991")]
        public void TestOperatorMultiplication_CalculateRealCases_ShouldBeEqualToExpected(string a, string b, string expected)
        {
            test<MbcUInteger>(a, b, expected, (x, y) => x * y);
        }

        [Test]
        [TestCase("999", "1", "999")]
        [TestCase("0", "999", "0")]
        [TestCase("8888", "8888", "1")]
        [TestCase("888", "999", "0")]
        public void TestOperatorDivision_CalculateBorserCases_ShouldBeEqualToExpected(string a, string b, string expected)
        {
            test<MbcUInteger>(a, b, expected, (x, y) => x / y);
        }

        [Test]
        [TestCase("248", "2", "124")]
        [TestCase("248", "23", "10")]
        [TestCase("24865634", "23453", "1060")]
        [TestCase("24865639248629583", "892739", "27853201494")]
        [TestCase("239849849839823235235239849849839823235235", "693847", "345681180202297098978938944536533015")]
        [TestCase("239849849839823235235239849849839823235235", "23984984983982323523523984984983982323523", "10")]
        public void TestOperatorDivision_CalculateRealCases_ShouldBeEqualToExpected(string a, string b, string expected)
        {
            test<MbcUInteger>(a, b, expected, (x, y) => x / y);
        }

        [Test]
        public void TestOperatorDivsion_DevideByZero_ShouldBeException()
        {
            var first = new MbcUInteger(100);
            var second = new MbcUInteger(0);

            Assert.Throws<System.DivideByZeroException>(delegate { var result = first / second; });
        }

        [Test]
        [TestCase("10", "1", "0")]
        [TestCase("999", "999", "0")]
        [TestCase("0", "879", "0")]
        [TestCase("357", "895", "0")]
        [TestCase("3587", "15", "2")]
        [TestCase("239849849839823235235239849849839823235235", "23984984983982323523523984984983982323523", "5")]
        public void TestOperatorModulo_CheckCalculationResult_ShouldBeEqualToExpected(string a, string b, string expected)
        {
            var first = new MbcUInteger(a);
            var second = new MbcUInteger(b);
            var actual = (first % second).ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestOperatorModulo_DevideByZero_ShouldBeException()
        {
            var a = new MbcUInteger(100);
            var b = new MbcUInteger(0);

            Assert.Throws<System.DivideByZeroException>(delegate { var result = a % b; });
        }
    }
}