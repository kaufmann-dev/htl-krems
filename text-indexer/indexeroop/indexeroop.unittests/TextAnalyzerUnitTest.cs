using System;
using indexeroop;
using NUnit.Framework;

namespace Tests {
    public class TextAnalyzerUnitTest {
        [SetUp]
        public void Setup() { }

        [Test]
        public void TestWordAnalyzer() {
            ITextAnalyzer analyzer = new WordAnalyzer();

            string result = analyzer.Analyze("hallo mein lieber Freund. Das ist aber ein tolles Programm. Wie geht es dir?");
            Console.WriteLine(result);
            
            Assert.Pass();
        }
        
        [Test]
        public void TestIndexer() {
            ITextAnalyzer analyzer = new Indexer();

            string result = analyzer.Analyze("hullo.hallo?hallo");
            Console.WriteLine(result);
            
            Assert.Pass();
        }

        [Test]
        public void TestIn() {
            String value = "hello";
            int intValue = 0;
            
            for (int i = 0; i < value.Length; i++) {
                intValue = (int) value[i] + 5;
             
            }
        }
    }
}