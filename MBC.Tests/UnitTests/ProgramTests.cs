using NUnit.Framework;

namespace MBC.Tests
{
    [TestFixture, Category("UnitTest")]
    public class ProgramTests
    {
        [Test]
        public void test()
        {
            Program.Main(new[] { "10", "100" });

            Assert.That(true, Is.EqualTo(true));
        }
    }
}