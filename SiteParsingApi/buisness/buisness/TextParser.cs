
using business.abstractions;
using HtmlAgilityPack;
using business.Exceptions;

namespace business
{
    public class TextParser : ITextParser
    {
        public List<string> GetWordsList(string url)
        {
            HtmlDocument document;
            HtmlWeb web = new HtmlWeb();
            try
            {
                document = web.Load(url);
             }
            catch 
            {   
                throw new WrongUrlException();
            }
            return document.GetWordsList();
        }
    }
}
