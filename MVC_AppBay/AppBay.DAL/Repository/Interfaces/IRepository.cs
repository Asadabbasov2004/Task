using AppBay.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.DAL.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity,new()
    {
      public DbSet<T> Table { get; }
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task CreateAsync(T entity);
        public void UpdateAsync(T entity);
        public void DeleteAsync(T entity);
        public Task<int> SaveChangesAsync();
    }
}
