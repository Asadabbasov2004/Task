using Microsoft.EntityFrameworkCore;

namespace EntityFirstTask
{
    internal class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=ASUS-TUF-F17;database=EntityFirstTask;Trusted_connection=true;Integrated security = true;Encrypt=false;");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }


    }
}
