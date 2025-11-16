using EventUber.Domain.Entities;

namespace EventUber.Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<T?> GetByIdAsync(Guid id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(Guid id);

    }
}