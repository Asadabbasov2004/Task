using BlankApp.Core.Entities.Common;
using BlankApp.DAL.Context;
using BlankApp.DAL.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp.DAL.Repositories.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();


        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression= null,
            Expression<Func<TEntity, object>>? orderbyExpression = null,
            bool isDescending = false,
             params string[] includes)
        {
            IQueryable<TEntity> query = Table.Where(c=>!c.IsDeleted);

            if (expression is not null)
            {
                query = query.Where(expression);
            }
            if (orderbyExpression != null)
            {
                query = isDescending ? query.OrderByDescending(orderbyExpression) : query.OrderBy(orderbyExpression);
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
        public async Task Create(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        }


        public void Update(TEntity entity)
        {
            Table.Update(entity);
        }
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
