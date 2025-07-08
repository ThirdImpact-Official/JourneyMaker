using System.Linq.Expressions;

namespace SoundBoard.Repository.Interface
{
    public interface IRepository<T>
    {
        IQueryable<T> GetQueryable();
        Task<T> GetById(int id);
        Task<T> GetById(int id, Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllByPagination(int page, int pageSize);
        Task<IEnumerable<T>> GetAllByPagination(int page, int pageSize, Expression<Func<T, bool>> predicate);
        Task<T> AddEntity(T entity);
        Task<T> UpdateEntity(T entity);
        Task DeleteEntity(int id);
        Task<int> CountAsync();
    }
}
