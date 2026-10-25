using NUnit.Framework;

namespace dynamiclist.TestProject1
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
            Dynamicss list = new Dynamicss();

            list.Add(5);
            list.Add(13);
            list.Display();

            Assert.Pass();
        }
    }
}