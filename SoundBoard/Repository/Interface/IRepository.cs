using System.Linq.Expressions;

namespace SoundBoard.Repository.Interface
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Get queryable
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetQueryable();
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(int id);
        /// <summary>
        /// Get entity by id based on predicate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> GetById(int id, Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Get all entities 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// Get all entities based on predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Get all entities by pagination
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllByPagination(int page, int pageSize);
        /// <summary>
        /// Get all entities by pagination with a condition
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllByPagination(int page, int pageSize, Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddEntity(T entity);
        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateEntity(T entity);
        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> DeleteEntity(int id);
        /// <summary>
        /// Get count of entities
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();
    }
}
