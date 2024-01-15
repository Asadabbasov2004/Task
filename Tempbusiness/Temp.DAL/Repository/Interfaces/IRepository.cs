using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temp.Core.Entities.Common;

namespace Temp.DAL.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseAudiTable,new()
    {
        public DbSet<T> Table { get; }
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetbyIdAsync(int id);
        public Task CreateAsync(T entity);
        public void UpdateAsync(T entity);
        public void DeleteAsync(T entity);

        public Task<int> SaveChangeAsync();
    }
}
