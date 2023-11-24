using Pustok_MVC.Areas.Admin.ViewModels;
using Pustok_MVC.Models;

namespace Pustok_MVC.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
           
        }
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Blog> blogs {get; set; }
        public DbSet<BookImg> bookImgs { get; set; }
        public DbSet<Catagory> catagories { get; set; }
        public DbSet<Slider> slider { get; set; }
        public DbSet<AdminVM> adminVMs { get; set; }
    }
}
