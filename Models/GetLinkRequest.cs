namespace LinkShortenerEF.Models
{
    public class GetLinkRequest
    {
        public int? Page { get; set; } = 1;
        public string Search { get; set; }
    }
}