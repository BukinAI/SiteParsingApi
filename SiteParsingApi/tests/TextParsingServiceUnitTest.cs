using business;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace tests
{
    public class TextParsingServiceUnitTest
    {
      

        private TextParsingService textParsingService;

        [SetUp]
        public void Setup()
        {
            var textParser = new TextParser();
            var textGrouper = new TextGrouper();
            textParsingService = new TextParsingService(textParser, textGrouper);
        }

        [Test]
        public void GetWordsList()
        {
            try
            {
                var isSuccess = false;
                var isSuccess1 = false;
                var isSuccess2 = false;
                var wordsList = textParsingService.GetWordsList("https://translate.google.ru");
                foreach (var item in wordsList)
                {
                    if (item.Word == "Перевод")
                    {
                        isSuccess1 = true;
                    }
                    if (item.Word == "Google")
                    {
                        isSuccess2 = true;
                    }
                }
                isSuccess = isSuccess1 && isSuccess2;
                Assert.IsTrue(isSuccess);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}