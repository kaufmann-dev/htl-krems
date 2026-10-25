using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using combatSimOOP;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace Tests {
    public class PointTests {
        [SetUp]
        public void Setup() { }

        [Test]
        public void TestPointMethods() {
            Point p = new Point(3,4);
            var controlZone = p.CalculateControlZone();

            Assert.AreEqual(8, controlZone.Count);
            
            Point p1 = controlZone[0];
            Point p2 = controlZone[7];
            
            Assert.IsTrue(p1.IsEqual(new Point(2,3)));
            Assert.IsTrue(p2.IsEqual(new Point(4,5)));
            
            Point k1 = new Point(3,4);
            Point k2 = new Point(4,6);
            Point k3 = new Point(4,5);
            
            Assert.AreEqual(EHorizontalPosition.TO_THE_LEFT, k1.DetermineHorizontalPosition(k2));
            Assert.AreEqual(EHorizontalPosition.TO_THE_RIGHT, k2.DetermineHorizontalPosition(k1));
            Assert.AreEqual(EHorizontalPosition.EQUAL, k1.DetermineHorizontalPosition(k1));
            
            Assert.AreEqual(EVerticalPosition.BELOW, k1.DetermineVerticalPosition(k2));
            Assert.AreEqual(EVerticalPosition.ABOVE, k2.DetermineVerticalPosition(k1));
            Assert.AreEqual(EVerticalPosition.EQUAL, k1.DetermineVerticalPosition(k1));
        }

        [Test]
        public void TestCalculateRoute() {
            Point p1 = new Point(2,3);
            Point p2 = new Point(6, 5);
            
            Point p3 = new Point(2, 7);
            Point p4 = new Point(5, 3);

            List<Point> route = p1.CalculateRoute(p2);
            
            Assert.AreEqual(6, route.Count);
            Assert.IsTrue(route[0].IsEqual(new Point(3,3)));
            Assert.IsTrue(route[5].IsEqual(new Point(6,5)));

            route = p2.CalculateRoute(p1);
            
            Assert.AreEqual(6, route.Count);
            Assert.IsTrue(route[0].IsEqual(new Point(5,5)));
            Assert.IsTrue(route[5].IsEqual(new Point(2,3)));

            route = p1.CalculateRoute(p1);
            Assert.AreEqual(0, route.Count);

            route = p1.CalculateRoute(p3);
            
            Assert.AreEqual(4, route.Count);
            Assert.IsTrue(route[0].IsEqual(new Point(2,4)));
            Assert.IsTrue(route[3].IsEqual(new Point(2,7)));

            route = p1.CalculateRoute(p4);
            
            Assert.AreEqual(3, route.Count);
            Assert.IsTrue(route[0].IsEqual(new Point(3,3)));
            Assert.IsTrue(route[2].IsEqual(new Point(5,3)));
            
        }
    }
}