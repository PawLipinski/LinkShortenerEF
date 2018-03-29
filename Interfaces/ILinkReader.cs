using System.Collections.Generic;
using WebDevHomework.Models;

namespace WebDevHomework.Interfaces
{
    public interface ILinkReader
    {
        List<Link> GetLinks(int count);
        string GetFullLink(string shortLink);
    }
}