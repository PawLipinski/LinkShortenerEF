using WebDevHomework.Models;

namespace LinkShortenerEF.Models
{
    public class CreateLinkRequest
    {
        public int Id { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }

        public Link GetLink()
        {
            var link = new Link
            {
                Id = this.Id,
                FullUrl = this.FullUrl,
                ShortUrl = this.ShortUrl 
            };

            return link;
        }
    }
}