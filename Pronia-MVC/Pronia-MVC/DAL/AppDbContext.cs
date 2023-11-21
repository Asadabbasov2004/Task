using Pronia_MVC.Models;

namespace Pronia_MVC.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet <Slider> sliders { get; set; }
        public DbSet <Product> products { get; set; }
        public DbSet <Category> categories { get; set; }
        public DbSet <Tag> tags { get; set; }
        public DbSet<ProductTag> productTags { get; set; }
        public DbSet<ProductImages> productImages { get; set; }
    }
}
