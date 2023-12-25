using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Core.Entities;

namespace UdemyApp.DAL.Context
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Course> courses { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<StudentsCourses> studentsCourses { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Category> categories { get; set; }

    }
}
