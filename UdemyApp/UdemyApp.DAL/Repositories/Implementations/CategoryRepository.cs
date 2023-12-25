using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Core.Entities;
using UdemyApp.DAL.Context;
using UdemyApp.DAL.Repositories.Interfaces;

namespace UdemyApp.DAL.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbcontext context) : base(context)
        {
        }
    }
}
