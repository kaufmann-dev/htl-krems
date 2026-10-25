using System;
using Algodat;
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
            Console.Beep();
            
            Assert.AreEqual(6, Algorithm.Mult(3,2));
            Assert.AreNotEqual(6, Algorithm.Mult(3,3));
            
            Assert.AreEqual(6, Algorithm.MultRec(3,2));
            Assert.AreNotEqual(6, Algorithm.MultRec(3,3));
            
            Assert.AreEqual(120, Algorithm.F(5));
            Assert.AreNotEqual(120, Algorithm.F(6));
            
            Assert.AreEqual(11, Algorithm.AddRec(4, 7));
            Assert.AreNotEqual(11, Algorithm.AddRec(5, 8));
            
            Assert.AreEqual(8, Algorithm.Fibonacci(5));
            Assert.AreNotEqual(11, Algorithm.Fibonacci(5));
            
            Assert.AreEqual(2, Algorithm.GGT(58,18));
            Assert.AreNotEqual(4, Algorithm.GGT(58, 18));
            
            Assert.AreEqual(10, Algorithm.Modulo(58,16));
            Assert.AreNotEqual(32, Algorithm.Modulo(58, 16));

            int[] list = new[] {32, 62, 64, 94};
            Assert.True(Algorithm.BinarySearch(list, 64, 0, list.Length - 1));
            Assert.False(Algorithm.BinarySearch(list, 63, 0, list.Length - 1));
        }

        [Test]
        public void TestSort()
        {
            int[] a = new[] {65, 7, 23, 1, 89};
            Algorithm.SelectionSort(a);
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }

            Apple[] b = new[]
                {
                    new Apple(12, "golden delicious"),
                    new Apple(14, "pink lady"),
                    new Apple(7, "epstein golden")
                };
            
            Algorithm.SelectionSort(b);
            foreach (var apple in b)
            {
                Console.WriteLine(apple.ToString());
            }
        }
    }
}