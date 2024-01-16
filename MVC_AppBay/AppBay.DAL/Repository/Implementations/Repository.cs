using AppBay.Core.Entities.Common;
using AppBay.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.DAL.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T entity)
        {
            entity.Created = DateTime.Now;
            await Table.AddAsync(entity);
        }

        public  void DeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            Table.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = Table.Where(e => e.IsDeleted == false);
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            IQueryable<T> query = Table.Where(e => e.IsDeleted == false);
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
            int res = await _context.SaveChangesAsync();

            return res;
        }

        public void UpdateAsync(T entity)
        {
            Table.Update(entity);   
        }
    }
}
