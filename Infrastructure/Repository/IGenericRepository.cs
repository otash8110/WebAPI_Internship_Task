namespace Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity);
        public Task<T> Update(T entity);
        public Task<T> GetOne(int id);
        public Task Delete(T entity);
        public Task Delete(int id);
        public Task<ICollection<T>> Get();
    }
}
