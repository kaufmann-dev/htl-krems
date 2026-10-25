namespace indexeroop {
    public class TextReport {

        private readonly string _text;

        public string Text => _text;

        private ITextAnalyzer _analyzer;

        public ITextAnalyzer Analyzer {
            set => _analyzer = value;
        }

        public TextReport(string text) {
            this._text = text;
        }

        public string Generate() {
            return _analyzer.Analyze(_text);
        }
    }
}