using domain;

namespace business.abstractions
{
    public interface ITextParsingService
    {

        List<WordAndCount> GetWordsList(string url);


    }



}