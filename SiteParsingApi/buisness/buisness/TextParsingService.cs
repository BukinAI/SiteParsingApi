using business.abstractions;
using domain;

namespace business
{
    public class TextParsingService : ITextParsingService
    {
        private ITextParser textParser;
        private ITextGrouper textGrouper;

        public TextParsingService(ITextParser textParser, ITextGrouper textGrouper)
        {
            this.textParser = textParser;
            this.textGrouper = textGrouper;
        }

        public List<WordAndCount> GetWordsList(string url)
        {
            var words = textParser.GetWordsList(url);
            var result = textGrouper.GetWordsAndCount(words);
            return  result;
        }
    }
}

