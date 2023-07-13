using Core.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<T> GetOneAsync(int id)
        {
            var result = await context.Set<T>().Where(e => e.Id == id).FirstOrDefaultAsync();

            return result;
        }

        public async Task<ICollection<T>> GetAsync()
        {
            var result = await context.Set<T>().ToListAsync();

            return result;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var result = context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = context.Set<T>().Find(id);
            context.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
