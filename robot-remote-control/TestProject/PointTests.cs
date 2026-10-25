using NUnit.Framework;
using Robo;

namespace TestProject
{
    public class PointTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            Point p1 = new Point(3, 3);
            
            Point p2 = p1.CalculateNeighbor(EDirectionType.NORTH);
            Point p3 = new Point(3,2);
            Assert.AreEqual(p2, p3);
            Assert.AreNotEqual(p1,p2);
            
            Point p4 = p1.CalculateNeighbor(EDirectionType.EAST);
            Point p5 = new Point(4,3);
            Assert.AreEqual(p4, p5);
            
            Point p6 = p1.CalculateNeighbor(EDirectionType.SOUTH);
            Point p7 = new Point(3,4);
            Assert.AreEqual(p6, p7);
            
            Point p8 = p1.CalculateNeighbor(EDirectionType.WEST);
            Point p9 = new Point(2,3);
            Assert.AreEqual(p8, p9);
        }
    }
}