namespace Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> GetOneAsync(int id);
        public Task DeleteAsync(T entity);
        public Task DeleteAsync(int id);
        public Task<ICollection<T>> GetAsync();
    }
}
