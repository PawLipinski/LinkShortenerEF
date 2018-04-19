using System.Collections.Generic;
using WebDevHomework.Models;

namespace WebDevHomework.Interfaces
{
    public interface ILinkReader
    {
        List<Link> GetLinks();
        LinkResult GetLinks(int page);
        string GetFullLink(string shortLink);
    }
}