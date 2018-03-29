using Microsoft.EntityFrameworkCore;
using WebDevHomework.Models;

namespace LinkShortenerEF
{
    public class LinkDbContext : DbContext
    {
        public LinkDbContext(DbContextOptions<LinkDbContext> options): base(options)
        {
            
        }

        public DbSet<Link> Links { get; set; }
    }
}