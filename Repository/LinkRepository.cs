using System;
using System.Collections.Generic;
using System.Linq;
using LinkShortenerEF;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;
using LinkShortenerEF.Repository;
using Microsoft.EntityFrameworkCore;

namespace WebDevHomework.Repository
{
    public class LinkRepository : ILinkRepository
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
        
        public (IEnumerable<Link>, int) Get(string search, int skip)
        {
            var stopsFilteredByName = search != null ? _context.Links
            .Where(x => x.FullUrl.ToLower()
            .Contains(search)) : _context.Links;
            var stopsCount = stopsFilteredByName.Count();

            var paginatedStop = stopsFilteredByName
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(20);

            return (paginatedStop, stopsCount);
        }
        
        public Link DeleteLink(int linkId)
        {
            var itemToRemove = _context.Links.SingleOrDefault(element => element.Id == linkId);
            _context.Links.Remove(itemToRemove);
            _context.SaveChanges();
            return itemToRemove;
        }

        public string GetFullLink(string shortLink)
        {
            var id = _hashDecoder.Decode(shortLink);
            return _context.Links.FirstOrDefault(link => link.Id == id).FullUrl;
        }

        public Link Update(Link link)
        {
            _context.Links.Attach(link);
            _context.Entry(link).State = EntityState.Modified;
            _context.SaveChanges();
            return link;
        }

        public (IEnumerable<Link>, int) Get(int skip, int itemPerPage)
        {
            var linksCount = _context.Links.Count();

            var paginatedLink = _context.Links
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(itemPerPage);

            return (paginatedLink, linksCount);
        }
    }
}