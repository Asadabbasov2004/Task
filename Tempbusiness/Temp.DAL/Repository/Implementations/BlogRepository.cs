using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temp.Core.Entities;
using Temp.DAL.DbContext;
using Temp.DAL.Repository.Interfaces;

namespace Temp.DAL.Repository.Implementations
{
    public class BlogRepository : Repository<Blog>, IBlogRepsoitory
    {
        public BlogRepository(AppDbcontext context) : base(context)
        {
        }
    }
}
