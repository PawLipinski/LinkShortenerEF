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
        public void AddLink(Link link)
        {
            _linkRepository.AddLink(link);
        }

        public void DeleteLink(int linkId)
        {
            _linkRepository.DeleteLink(linkId);
        }
    }
}