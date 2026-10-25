using NUnit.Framework;
using Shogun;

namespace TestProject
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
            TestClassVector v1 = new TestClassVector(32, 67);
            
            Assert.AreEqual(v1.X, 32);
            Assert.AreEqual(v1.Y, 67);

            Animal a1 = new Animal(3, 4, 12, "red");
            Assert.AreEqual(3, a1.X);
            Assert.AreEqual(4, a1.Y);
        }
    }
}