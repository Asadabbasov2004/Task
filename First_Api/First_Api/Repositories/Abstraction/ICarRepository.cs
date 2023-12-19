using First_Api.Entities;
using System.Linq.Expressions;

namespace First_Api.Repositories.Abstraction
{
    public interface ICarRepository
    {
        Task<IQueryable<Car>> GetAll(Expression<Func<Car, bool>>? expression = null, params string[] includes);
        Task<Car> GetById(int id);
        Task Create(Car brand);
        void Update(Car brand);
        void Delete(Car brand);
        Task SaveChangeAsync();
    }
}
