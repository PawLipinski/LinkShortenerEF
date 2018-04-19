using System.Linq;
using LinkShortenerEF.Models;
using LinkShortenerEF.Repository;
using Microsoft.AspNetCore.Mvc;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

namespace LinkShortenerEF.Controllers
{
    [Route("/api/links")]
    public class LinkAPIController : Controller
    {

        //private readonly ILinkRepository repository;

        private readonly ILinkReader _linkReader;
        private readonly ILinkWriter _linkWriter;
        //private int itemPerPage = 10;

        public LinkAPIController(ILinkReader reader, ILinkWriter writer)
        {
            this._linkReader = reader;
            this._linkWriter = writer;
        }

        [HttpGet]
        // public IActionResult Get()        
        public IActionResult Index([FromQuery]GetLinkRequest request)
        {
            var result = _linkReader.GetLinks(request.Page.Value);

            return Ok(result);
        }

        // [HttpGet]
        // public IActionResult Index(int? page = 1)
        // {
        //     var result = _linkReader.GetLinks(page.Value);
        //     return Ok(result);
        // }


        [HttpDelete]
        public IActionResult Delete(int linkId)
        {
            _linkWriter.DeleteLink(linkId);
            return Ok();
        }


        [HttpPost]
        public IActionResult Create(Link link)
        {
            _linkWriter.AddLink(link);
            return Ok(link);
        }

    }
}