using System;
using System.Collections.Generic;
using System.Linq;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

namespace WebDevHomework.Repository
{
    public class LinkRepository
    {
        private readonly List<Link> _links;
        private readonly IHashDecoder _hashDecoder;
        private readonly IHashEncoder _hashEncoder;

        public LinkRepository(IHashDecoder hashDecoder, IHashEncoder hashEncoder)
        {
            _links = new List<Link>();
            _hashDecoder = hashDecoder;
            _hashEncoder = hashEncoder;
        }

        public List<Link> GetLinks()
        {
            return _links;
        }

        public void AddLink(Link link)
        {
            var random = new Random();
            link.Id = random.Next(100000, 1000000);
            // no hash collision check
            // can generate same hash for different links
            link.ShortUrl = _hashEncoder.Encode(link.Id);
            _links.Add(link);
        }

        public void DeleteLink(int linkId)
        {
            var itemToRemove = _links.SingleOrDefault(element => element.Id == linkId);
            _links.Remove(itemToRemove);
        }

        public string GetFullLink(string shortLink)
        {
            var id = _hashDecoder.Decode(shortLink);
            return _links.SingleOrDefault(link => link.Id == id).FullUrl;
        }

    }
}