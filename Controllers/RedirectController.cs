using Microsoft.AspNetCore.Mvc;
using WebDevHomework.Interfaces;

namespace WebDevHomework.Controllers
{
    public class RedirectController : Controller
    {
        private readonly ILinkReader _linkReader;

        public RedirectController(ILinkReader linkReader)
        {
            _linkReader = linkReader;
        }

        [HttpGet("/{shortUrl}")]
        public IActionResult RedirectToUrl(string shortUrl)
        {
            if(shortUrl == "favicon.ico") return RedirectToPage("Index");
            var fullUrl = _linkReader.GetFullLink(shortUrl);
            var lowercaselink = fullUrl.ToLower();
            if(lowercaselink.Contains("http://") || lowercaselink.Contains("https://")){
                return Redirect(fullUrl);
            }
            return Redirect($"http://{fullUrl}");
        }
    }
}