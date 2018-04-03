using System;
using System.Collections.Generic;
using System.Linq;
using LinkShortenerEF;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

namespace WebDevHomework.Repository
{
    public class LinkRepository
    {
        private readonly LinkDbContext _context;
        private readonly IHashDecoder _hashDecoder;
        private readonly IHashEncoder _hashEncoder;

        public LinkRepository(LinkDbContext context, IHashDecoder hashDecoder, IHashEncoder hashEncoder)
        {
            _context = context;
            _hashDecoder = hashDecoder;
            _hashEncoder = hashEncoder;
        }

        public List<Link> GetLinks()
        {
            return _context.Links.ToList();
        }

        public Link AddLink(Link link)
        {
            var random = new Random();
            link.Id = random.Next(100000, 1000000);
            // no hash collision check
            // can generate same hash for different links
            link.ShortUrl = _hashEncoder.Encode(link.Id);
            _context.Links.Add(link);
            _context.SaveChanges();
            return link;
        }

        public void DeleteLink(int linkId)
        {
            var itemToRemove = _context.Links.SingleOrDefault(element => element.Id == linkId);
            _context.Links.Remove(itemToRemove);
            _context.SaveChanges();
        }

        public string GetFullLink(string shortLink)
        {
            var id = _hashDecoder.Decode(shortLink);
            return _context.Links.SingleOrDefault(link => link.Id == id).FullUrl;
        }

    }
}