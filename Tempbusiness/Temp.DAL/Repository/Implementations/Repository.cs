using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Temp.Core.Entities.Common;
using Temp.DAL.DbContext;
using Temp.DAL.Repository.Interfaces;

namespace Temp.DAL.Repository.Implementations
{
    public class Repository<T>: IRepository<T> where T : BaseAudiTable, new()
    {
        private readonly AppDbcontext _context;

        public Repository(AppDbcontext  context)
        {
          _context = context;
        }
        public DbSet<T> Table =>_context.Set<T>();

        public async Task CreateAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
           await Table.AddAsync(entity);
        }

        public  async void DeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
            Table.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> entities = Table;
            return await entities.ToListAsync();
         }

        public async Task<T> GetbyIdAsync(int id)
        {
            T entity = await Table.FirstOrDefaultAsync(x => x.Id == id);
            return  entity;
        }

        public async Task<int> SaveChangeAsync()
        {
            var res = await _context.SaveChangesAsync();
            return res;
        }

        public async void UpdateAsync(T entity)
        {
             Table.Update(entity);
        }
    }
}
