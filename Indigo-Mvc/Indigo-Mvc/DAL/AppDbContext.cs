using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Indigo_Mvc.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ):base(options)
        {
          
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Images> Images { get; set; }
    }
}
