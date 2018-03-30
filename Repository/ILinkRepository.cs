using System.Collections.Generic;
using WebDevHomework.Models;

namespace LinkShortenerEF.Repository
{
    public interface ILinkRepository
    {
        (IEnumerable<Link>, int) Get(int skip);
        Link Get(int Id, bool isOneNeeded);
        Link Create(Link stop);
        Link Update(Link stop);
        void Delete(int id);    
    }
}