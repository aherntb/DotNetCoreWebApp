using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebApp
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Claim> Claims{ get; set; }
    }
}