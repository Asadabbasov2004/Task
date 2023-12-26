using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Core.Entities.Common;
using UdemyApp.DAL.Context;
using UdemyApp.DAL.Repositories.Interfaces;

namespace UdemyApp.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseAudiTableEntity, new()
    {
        protected readonly DbContext _context;


        public Repository(DbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        //public Task DeleteAsync(int Id)
        //{
        //}

        public Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>? orderbyExpression = null, bool isDescending = false, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> IsExist(int id)
        {
           return await Table.AnyAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<int> SaveChangesAsync()
        {
          return  await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}   


