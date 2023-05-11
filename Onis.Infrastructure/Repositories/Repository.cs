using Microsoft.EntityFrameworkCore;
using Onis.Domain.Contracts;
using Onis.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onis.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly CatalogDBContext _context;

        public Repository(CatalogDBContext context)
        {
            _context = context;
        }

        protected DbSet<T> EntitySet
        {
            get
            {
                return _context.Set<T>();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }

        public DbSet<T> GetEntitySet()
        {
            return EntitySet;
        }

        public async Task<T> GetByID(int id, DbSet<T> entitySet)
        {
            return await entitySet.FindAsync(id);
        }

        public async Task<T> Insert(T entity)
        {
            EntitySet.Add(entity);
            await Save();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            T entity = await entitySet.FindAsync(id);
            EntitySet.Remove(entity);
            await Save();
            return entity;
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<T> Find(Expression<Func<T, bool>> expr)
        {
            return await EntitySet.AsNoTracking().FirstOrDefaultAsync(expr);
        }

        public Task<T> GetByID(int? id)
        {
            throw new NotImplementedException();
        }
    }




}
