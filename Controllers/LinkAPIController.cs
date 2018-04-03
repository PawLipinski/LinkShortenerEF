using LinkShortenerEF.Models;
using LinkShortenerEF.Repository;
using Microsoft.AspNetCore.Mvc;
using WebDevHomework.Models;

namespace LinkShortenerEF.Controllers
{
    public class LinkAPIController : Controller
    {
        
        private readonly ILinkRepository repository;
        //private int itemPerPage = 10;
        public LinkAPIController(ILinkRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public JsonResult Get([FromQuery]GetLinkRequest request)
        {
            return Json(repository.GetLinks());
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