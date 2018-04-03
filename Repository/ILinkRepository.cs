using System.Collections.Generic;
using WebDevHomework.Models;

namespace LinkShortenerEF.Repository
{
    public interface ILinkRepository
    {
        List<Link> GetLinks();

        Link AddLink(Link link);


        Link DeleteLink(int linkId);

        string GetFullLink(string shortLink);

        Link Update(Link link);

    }
}