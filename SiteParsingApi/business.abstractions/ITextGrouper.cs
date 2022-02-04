
using domain;

namespace business.abstractions
{
    public interface ITextGrouper
    {
        List<WordAndCount> GetWordsAndCount(List<string> words);
    }
}
