using System;
using System.Collections.Generic;
using System.Text;

namespace indexeroop {
    public class WordAnalyzer : ITextAnalyzer {
        
        public string Analyze(string text) {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Textreport:");
            stringBuilder.AppendLine();
            //
            int sentenceCount = 0;
            int wordCount = 0;
            
            foreach (var sentence in text.Split(new char[]{'.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries)) {
                ++sentenceCount;
                
                stringBuilder.Append(sentenceCount);
                stringBuilder.Append(". Sentence: wordcount is ");
                stringBuilder.Append(sentence.Split(' ').Length);
                stringBuilder.AppendLine();
            }
            
            return stringBuilder.ToString();
        }

    }
}