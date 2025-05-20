using Microsoft.EntityFrameworkCore;
using School.DAL;
using School.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SchoolDbContext _context;
        private readonly DbSet<T> _dbSet;


        public Repository(SchoolDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task DeleteAsync(T entity)
        {
           _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
          return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }
    }
}
