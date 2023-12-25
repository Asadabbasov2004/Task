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
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[] includes);

        Task<T> GetById(int id);
        Task Create(T entity);
        void Update(T entity);
        void delete(int id);
        void deleteAll();
        void Save();

    }

}
