using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Core.Entities.Common;

namespace UdemyApp.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseAudiTableEntity, new()
    {
        DbSet<T> Table { get; }
        Task<IQueryable<T>> GetAllAsync(
            Expression<Func<T, bool>>? expression = null,
           Expression<Func<T,object>>? orderbyExpression =null,
           bool isDescending = false,
            params string [] includes
        );

        Task<T> FindByIdAsync(int id);
        Task CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
       // Task DeleteAsync(int Id);
        Task<int> SaveChangesAsync();
        Task<bool> IsExist(int id);

    }

}
