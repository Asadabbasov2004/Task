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
    public class Repository<T> : IRepository<T> where T : BaseAudiTable, new()
    {
        private readonly AppDbcontext _context;

        public Repository(AppDbcontext context)
        {
            _context = context;
        }
        public DbSet<T> Table =>_context.Set<T>() ;

        public async Task CreateAsync(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
             await Table.AddAsync(entity);
        }

        public async void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            Table.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = Table.Where(e => !e.IsDeleted);
            return await query.ToListAsync();
        }

        public async Task<T> GetbyIdAsync(int id)
        {
            IQueryable<T> query = Table.Where(e => !e.IsDeleted);
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> SaveChangeAsync()
        {
            var res =await _context.SaveChangesAsync();
            return res;
        }

        public void Update(T entity)
        {
            entity.UpdatedAt= DateTime.Now;
            Table.Update(entity);
        }
    }
}
