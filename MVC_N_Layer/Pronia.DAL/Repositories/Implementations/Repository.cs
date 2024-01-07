using Microsoft.EntityFrameworkCore;
using Pronia.Core.Entities.Common;
using Pronia.DAL.Repositories.Interfaces;
using Pronia.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.DAL.Repositories.Implementations
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



        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>? orderbyExpression = null, bool isDescending = false, params string[] includes)
        {
            IQueryable<T> query = Table.Where(e => !e.IsDeleted);
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (orderbyExpression != null)
            {
                query = isDescending ? query.OrderByDescending(orderbyExpression)
                    : query.OrderBy(orderbyExpression);
            }
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
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
            return await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Remove(int id)
        {
            (await FindByIdAsync(id)).IsDeleted = true;
        }
    }

 
}
