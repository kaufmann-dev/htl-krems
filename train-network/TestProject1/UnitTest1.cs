using System.Drawing;
using NUnit.Framework;

namespace TestProject1 {
    public class Tests {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Point p1 = new Point(3,3);
            Point p2 = new Point(3,3);
            Point p3 = new Point(3, 4);

            Assert.True(p1.Equals(p2));
            Assert.False(p1.Equals(p3));
        }
    }
}