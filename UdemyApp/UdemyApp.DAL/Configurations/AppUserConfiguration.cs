using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Core.Entities;

namespace UdemyApp.DAL.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(user => user.Name)
                .IsRequired()       
                .HasMaxLength(25);  

            builder.Property(user => user.Surname)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(user => user.UserName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(50); 

            //builder.Property(user => user.PasswordHash)
            //    .IsRequired()
            //    .HasMaxLength(20);
        }
    }
}