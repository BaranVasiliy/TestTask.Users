using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Users.DAL.EF.DataContext;
using TestTask.Users.DAL.EF.Repositories.Contracts;

namespace TestTask.Users.DAL.EF.Repositories
{
    public class GenericRepository<TId, TEntity> : IGenericRepository<TId, TEntity> where TEntity : class
    {
        protected UserDbContext Context;

        public GenericRepository(UserDbContext context)
        {
            Context = context;
        }

        public virtual async Task<TEntity> GetByIdAsync(TId id)
        {
            return await  Context.Set<TEntity>().FindAsync(id);
        }

        public void Add(TEntity entity)
        { 
            Context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
    }
}