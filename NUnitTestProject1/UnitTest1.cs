using Moq;
using NUnit.Framework;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var mock = new Mock<IDbContext>();
            mock.Setup(x => x.)
        }
    }
}