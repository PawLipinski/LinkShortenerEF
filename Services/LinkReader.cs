using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;
using WebDevHomework.Repository;

namespace WebDevHomework.Services
{
    public class LinkReader : ILinkReader
    {
        private readonly LinkRepository _linkRepository;
        private readonly IConfiguration _configuration;

        public LinkReader(LinkRepository linkRepository, IConfiguration configuration)
        {
            _linkRepository = linkRepository;
            _configuration = configuration;
        }

        public string GetFullLink(string shortLink)
        {
            return _linkRepository.GetFullLink(shortLink);
        }

        public List<Link> GetLinks()
        {
            return _linkRepository.GetLinks();
        }

        public LinkResult GetLinks(int page)
        {
            var itemPerPage = _configuration.GetValue<int>("itemPerPage");
            var (linkList, count) = _linkRepository.Get((page - 1) * itemPerPage, itemPerPage);
            var result = new LinkResult
            {
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    MaxPage = count % itemPerPage == 0 ? count / itemPerPage : count / itemPerPage + 1
                },
                Items = linkList
            };
            return result;
             
        }
    }
}