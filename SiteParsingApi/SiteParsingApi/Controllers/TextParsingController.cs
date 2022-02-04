using business.abstractions;
using domain;
using Microsoft.AspNetCore.Mvc;

namespace SiteParsingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextParsingController : ControllerBase
    {
        private readonly ITextParsingService textParsingService;
        
        public TextParsingController(ITextParsingService textParsingService)
        {
            this.textParsingService = textParsingService;

        }

        [HttpGet]
        public List<WordAndCount> GetWords(string? url)  
        {
            return textParsingService.GetWordsList(url);
        }
    }
}