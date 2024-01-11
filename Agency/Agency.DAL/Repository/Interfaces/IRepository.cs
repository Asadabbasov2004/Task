using Agency.Core.Entities.Common;
using Agency.DAL.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.DAL.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        public DbSet<T> Table { get;  }
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task CreateAync(T entity);
        public void UpdateAync(T entity);
        public Task<T> DeleteAync(int Id);
        public Task<int> SavechangesAsync();
    }
}
