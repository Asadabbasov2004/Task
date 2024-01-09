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
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T> entity = await Table.ToListAsync();
            return entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T entity = await Table.FirstOrDefaultAsync(x => x.Id == id);
            return  entity;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async void Delete(int id)
        {
            T entity =await GetByIdAsync(id);
            Table.Remove(entity);
        }

     

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public  void UpdateAsync(T entity)
        {
            Table.Update(entity);  
        }
    }
}
