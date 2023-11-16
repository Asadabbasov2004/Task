using FrontToBackMVC_2.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackMVC_2.DAL
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Sliders> Sliders { get; set; }
        public DbSet<Work> Works { get; set; }
    }
}
