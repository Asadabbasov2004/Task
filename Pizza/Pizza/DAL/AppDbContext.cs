using Microsoft.EntityFrameworkCore;
using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.DAL
{

    internal class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-4EOUDP3;database=pizza;Trusted_connection=true;Integrated security=true;Encrypt=false");

        }
        public DbSet<Brand> brands { get; set; }   
        public DbSet<Owner> owners { get; set; }   
        public DbSet<Image> images { get; set; }   
        public DbSet<Product> products { get; set; }   
        public DbSet<Catagory> Catagories { get; set; }


    }
}
//DESKTOP-4EOUDP3