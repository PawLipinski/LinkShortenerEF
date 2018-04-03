using WebDevHomework.Interfaces;
using WebDevHomework.Models;
using WebDevHomework.Repository;

namespace WebDevHomework.Services
{
    public class LinkWriter : ILinkWriter
    {
        private readonly LinkRepository _linkRepository;

        public LinkWriter(LinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }
        public Link AddLink(Link link)
        {
            return _linkRepository.Create(link);
        }

        public void DeleteLink(int linkId)
        {
            _linkRepository.Delete(linkId);
        }
    }
}