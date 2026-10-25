using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace indexeroop {
    public class Indexer : ITextAnalyzer {
        
        private Dictionary<string, int> _dictionary = new Dictionary<string, int>();
        
        private void AddEntry(string word) {
            if (!_dictionary.ContainsKey(word))
                _dictionary[word] = 1;
            else
               _dictionary[word] = ++_dictionary[word];
        }
        
        public string Analyze(string text) {
            StringBuilder report = new StringBuilder();
            _dictionary.Clear();
            
            foreach (var sentence in text.Split(new char[]{'.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries)) {
                foreach (var word in sentence.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries)) {
                    AddEntry(word);           
                }
            }

            report.Append("Indexreport:");
            
            foreach (var word in _dictionary.Keys) {
                report.AppendLine();
                
                report.Append(word);
                report.Append(": ");
                report.Append(_dictionary[word]);
            }
            
            return report.ToString();
        }
    }
}