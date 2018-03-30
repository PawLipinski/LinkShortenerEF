using System.Linq;
using LinkShortenerEF.Models;
using LinkShortenerEF.Repository;
using Microsoft.AspNetCore.Mvc;
using WebDevHomework.Models;

namespace LinkShortenerEF.Controllers
{
    public class LinkAPIController : Controller
    {
        private readonly ILinkRepository repository;
        private int itemPerPage = 10;
        public LinkAPIController(ILinkRepository repository)
        {
            this.repository = repository;

        }

        [HttpGet("{id}")]
        // GET api/stops/{id}
        public IActionResult Get(int id, bool isOneNeeded)
        {
            return Ok(repository.Get(id, isOneNeeded));
        }

        //GET api/stops/?search={string}&page={int}
        [HttpGet("dupa")]
        public IActionResult Get([FromQuery]GetLinkRequest request)
        {
            var (links, count) = repository
                    .Get((request.Page.Value - 1) * itemPerPage);
            var result = new SearchResult
            {
                PageInfo = new PageInfo
                {
                    CurrentPage = request.Page.Value,
                    MaxPage = count % itemPerPage == 0 ? count / itemPerPage : count / itemPerPage + 1
                },
                Items = links.Select(x => new LinkResult(x))
            };
            return Ok(result);
        }

        // DELETE api/stops/{id}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return Ok();
        }

        //POST api/stops
        [HttpPost("wielki post")]
        public IActionResult Post([FromBody]CreateLinkRequest createLink)
        {
            return Ok(repository.Create(createLink.GetLink()));
        }

        //POST api/stops
        [HttpPut]
        public IActionResult Put([FromBody]Link stop)
        {
            return Ok(repository.Update(stop));
        }
    }
}