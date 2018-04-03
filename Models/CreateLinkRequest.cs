using WebDevHomework.Models;

namespace LinkShortenerEF.Models
{
    public class CreateLinkRequest
    {
        public string FullUrl{ get; set; }
        public string ShortUrl { get; set; }
        public Link GetLink()
        {
            var link = new Link
            {
                FullUrl = this.FullUrl,
                ShortUrl = this.ShortUrl
            };

            return link;
        }
    }

}