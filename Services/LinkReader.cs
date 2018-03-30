using System.Collections.Generic;
using System.Linq;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;
using WebDevHomework.Repository;

namespace WebDevHomework.Services
{
    public class LinkReader : ILinkReader
    {
        private readonly LinkRepository _linkRepository;

        public LinkReader(LinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public string GetFullLink(string shortLink)
        {
            return _linkRepository.GetFullLink(shortLink);
        }

        public List<Link> GetLinks(int count)
        {
            var (links,county) = _linkRepository.Get(count);
            return links.ToList();
            //return _linkRepository.Get(count).Item1;
        }
    }
}