using dynamiclist.dynamiclist;
using NUnit.Framework;

namespace TestProject3
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
            
            List<int> list = new List<int>();
            list.Add(1);
            list.AddRoot(2);
            list.AddRoot(3);
            Assert.AreEqual(3, list.Count());
            list.Remove(1);
            Assert.AreEqual(2,list.Count());
            Assert.Pass();
        }
    }
}