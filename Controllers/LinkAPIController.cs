using System.Linq;
using LinkShortenerEF.Models;
using LinkShortenerEF.Repository;
using Microsoft.AspNetCore.Mvc;
using WebDevHomework.Models;

namespace LinkShortenerEF.Controllers
{
    [Route("api/links")]
    public class LinkAPIController : Controller
    {

        private readonly ILinkRepository repository;
        private int itemPerPage = 10;

        public LinkAPIController(ILinkRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]GetLinkRequest request)
        {
            var (links, count) = repository
                            .Get(request.Search, (request.Page.Value - 1) * itemPerPage);
            var result = new SearchResult
            {
                PageInfo = new PageInfo
                {
                    CurrentPage = request.Page.Value,
                    MaxPage = count % itemPerPage == 0 ? count / itemPerPage : count / itemPerPage + 1
                },
                Items = links.Select(x => new LinkResult(x))
            };
            //return Ok(result);
            return Ok(result);
        }

        // DELETE api/stops/{id}
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            return Json(repository.DeleteLink(id));
        }

        //POST api/stops
        [HttpPost]
        public IActionResult Post([FromBody]CreateLinkRequest createLink)
        {
            return Json(repository.AddLink(createLink.GetLink()));
        }

        //POST api/stops
        [HttpPut]
        public JsonResult Put([FromBody]Link link)
        {
            return Json(repository.Update(link));
        }
    }
}