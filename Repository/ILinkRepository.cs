using System.Collections.Generic;
using WebDevHomework.Models;

namespace LinkShortenerEF.Repository
{
    public interface ILinkRepository
    {
        List<Link> GetLinks();

        (IEnumerable<Link>, int) Get(int skip, int itemsPerPage);

        Link AddLink(Link link);


        Link DeleteLink(int linkId);

        string GetFullLink(string shortLink);

        Link Update(Link link);

    }
}