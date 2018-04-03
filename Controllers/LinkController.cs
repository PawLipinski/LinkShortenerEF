using Microsoft.AspNetCore.Mvc;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

namespace WebDevHomework.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkWriter _linkWriter;
        private readonly ILinkReader _linkReader;

        public LinkController(ILinkReader linkReader, ILinkWriter linkWriter)
        {
            _linkReader = linkReader;
            _linkWriter = linkWriter;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var alllinks = _linkReader.GetLinks();
            return View(alllinks);
        }

        [HttpPost]
        public IActionResult Create(Link link)
        {
            _linkWriter.AddLink(link);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int linkId)
        {
            _linkWriter.DeleteLink(linkId);
            return RedirectToAction("Index");
        }
    }
}