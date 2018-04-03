using System;
using System.Collections.Generic;
using System.Linq;
using LinkShortenerEF;
using LinkShortenerEF.Repository;
using Microsoft.EntityFrameworkCore;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

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

        public (IEnumerable<Link>, int) Get(int skip)
        {
            var links = _context.Links.ToList();
            var linksCount = links.Count();

            var paginatedLink = links
                .OrderBy(x=> x.Id)
                .Skip(skip)
                .Take(20);

            return (paginatedLink, linksCount);
        }

        public Link Get(int Id, bool isOneNeeded)
        {
            return _context.Links.Find(Id);
        }

        public Link Create(Link link)
        {
            var random = new Random();
            link.Id = random.Next(100000, 1000000);
            link.ShortUrl = _hashEncoder.Encode(link.Id);
            _context.Links.Add(link);
            _context.SaveChanges();
            return link;
        }

        public void Delete(int linkId)
        {
            Link linkEntity = _context.Links.Find(linkId);
            _context.Links.Remove(linkEntity);
            _context.SaveChanges();
        }

        public string GetFullLink(string shortLink)
        {
            var id = _hashDecoder.Decode(shortLink);
            return _context.Links.SingleOrDefault(link => link.Id == id).FullUrl;
        }
        public Link Update(Link link)
        {
            _context.Links.Attach(link);
            _context.Entry(link).State = EntityState.Modified;
            _context.SaveChanges();
            return link;
        }
        
        #region old
        // public void AddLink(Link link)
        // {
        //     var random = new Random();
        //     link.Id = random.Next(100000, 1000000);
        //     // no hash collision check
        //     // can generate same hash for different links
        //     link.ShortUrl = _hashEncoder.Encode(link.Id);
        //     _links.Add(link);
        // }

        // public void DeleteLink(int linkId)
        // {
        //     var itemToRemove = _links.SingleOrDefault(element => element.Id == linkId);
        //     _links.Remove(itemToRemove);
        // }

        // public string GetFullLink(string shortLink)
        // {
        //     var id = _hashDecoder.Decode(shortLink);
        //     return _links.SingleOrDefault(link => link.Id == id).FullUrl;
        // }
        #endregion

    }
}