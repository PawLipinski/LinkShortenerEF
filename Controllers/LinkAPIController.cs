using LinkShortenerEF.Repository;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get(int id)
        {
            return Ok(repository.Get(id));
        }

        //GET api/stops/?search={string}&page={int}
        [HttpGet]
        public IActionResult Get([FromQuery]GetStopRequest request)
        {
            var (stops, count) = repository
                    .Get(request.Search, (request.Page.Value - 1) * itemPerPage);
            var result = new SearchResult
            {
                PageInfo = new PageInfo
                {
                    CurrentPage = request.Page.Value,
                    MaxPage = count % itemPerPage == 0 ? count / itemPerPage : count / itemPerPage + 1
                },
                Items = stops.Select(x => new StopResult(x))
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
        [HttpPost]
        public IActionResult Post([FromBody]CreateStopRequest createStop)
        {
            return Ok(repository.Create(createStop.GetStop()));
        }

        //POST api/stops
        [HttpPut]
        public IActionResult Put([FromBody]Stop stop)
        {
            return Ok(repository.Update(stop));
        }
    }
}