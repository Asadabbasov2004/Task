using First_Api.Entities;
using First_Api.Entities.Base;
using System.Linq.Expressions;

namespace First_Api.Repositories.Abstraction
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAll(Expression<Func<T ,bool>>? expression =null, Expression<Func<T, object>>? orderbyExpression = null,
            bool isDescending = false,
            params string[] includes);
        Task<T> GetById(int id);
        Task Create (T entity);
        void Update (T entity);
        void Delete (T entity);
        Task SaveChangeAsync();
    }
}
