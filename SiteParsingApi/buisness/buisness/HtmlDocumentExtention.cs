
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace business
{
    internal static class HtmlDocumentExtention
    {
        internal static List<string> GetWordsList(this HtmlDocument document)
        {
            var result = new List<string>();
            var siteInnerText = document.DocumentNode.InnerText;
            string pattern = @"[^A-Z|a-z|А-Я|а-я|\s]|[\n\r]";
            string target = " ";
            Regex regex = new Regex(pattern);
            siteInnerText = regex.Replace(siteInnerText, target);
            pattern = @"\s+";
            regex = new Regex(pattern);
            siteInnerText = regex.Replace(siteInnerText, target);
            result = siteInnerText.Split(new char[] { ' ' }).ToList();
            return result;
        }
    }
}
