using Agency.Core.Entities.Common;
using Agency.DAL.DbContext;
using Agency.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Agency.DAL.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public  async Task CreateAync(T entity)
        {
             await Table.AddAsync(entity);
        }

        public async Task<T> DeleteAync(int Id)
        {
            T entity = await GetByIdAsync(Id);
            entity.IsDeleted = true;
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> SavechangesAsync()
        {
             var  count =await _context.SaveChangesAsync();
            return count;
        }

        public  void UpdateAync(T entity)
        {
            Table.Update(entity);
        }
    }
}
