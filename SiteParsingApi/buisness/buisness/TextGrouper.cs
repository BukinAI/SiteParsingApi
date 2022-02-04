
using business.abstractions;
using domain;

namespace business
{
    public class TextGrouper : ITextGrouper
    {
        public List<WordAndCount> GetWordsAndCount( List<string> words)
        {
            var result = new List<WordAndCount>();
            var UniqwordList = new List<string>();

            foreach (var str in words)
            {

                var foundString = StringHelper.FindString(UniqwordList, str);
                if (foundString == null)
                {
                    UniqwordList.Add(str);
                }
            }

            foreach (var Uniqstr in UniqwordList)
            {

                var count = StringHelper.GetCount(words, Uniqstr);
                var word = new WordAndCount { Word = Uniqstr, Count = count };
                result.Add(word);
            }

            return result;
        }

    }
}
