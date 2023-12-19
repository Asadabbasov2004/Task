using First_Api.Entities;
using System.Linq.Expressions;

namespace First_Api.Repositories.Abstraction
{
    public interface IRepository
    {
        Task<IQueryable<Brand>> GetAll(Expression<Func<Brand ,bool>>? expression =null ,params string[] includes);
        Task<Brand> GetById(int id);
        Task Create (Brand brand);
        void Update (Brand brand);
        void Delete (Brand brand);
        Task SaveChangeAsync();
    }
}
