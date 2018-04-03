using WebDevHomework.Models;

namespace WebDevHomework.Interfaces
{
    public interface ILinkWriter
    {
        void DeleteLink(int linkId);
        Link AddLink(Link link);
    }
}