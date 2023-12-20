using First_Api.DAL;
using First_Api.Entities;
using First_Api.Repositories.Abstraction;

namespace First_Api.Repositories.Implementation
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
