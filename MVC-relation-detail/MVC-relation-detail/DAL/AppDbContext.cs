using Microsoft.EntityFrameworkCore;


namespace MVC_relation_detail.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<FoodImg> FoodImgs { get; set; }
        public DbSet<Food> Foods { get; set; }


    }
}
