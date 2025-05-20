
using System.Linq.Expressions;

namespace School.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(T entity);

        Task <IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    }

        // This interface can be used to mark all repository classes
        // and can be extended in the future if needed.

}
// This interface serves as a marker interface for all repositories in the application.