using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temp.Core.Entities;
using Temp.Core.Entities.Common;

namespace Temp.DAL.DbContext
{
    public class AppDbcontext : IdentityDbContext<AppUser>
    {
        public AppDbcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Blog> blogs { get; set; }

    }
}
