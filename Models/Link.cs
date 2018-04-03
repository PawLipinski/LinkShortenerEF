namespace WebDevHomework.Models
{
    public class Link
    {
        // Id used for creating hash for shortened link
        public int Id { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}