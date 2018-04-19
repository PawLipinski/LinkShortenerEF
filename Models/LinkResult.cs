using System.Collections.Generic;

namespace WebDevHomework.Models
{
    public class LinkResult
    {
        public IEnumerable<Link> Items { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public int CurrentPage { get; set; }

        public int MaxPage { get; set; }
    }
}