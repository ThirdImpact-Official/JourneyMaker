using Microsoft.EntityFrameworkCore;
using SoundBoard.Repository.Interface;
using System.Linq.Expressions;

namespace SoundBoard.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> AddEntity(T entity)
        {
            try
            {

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteEntity(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity != null)
                {
                    _context.Set<T>().Remove(entity);

                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>()
                                 .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByPagination(int page, int pageSize)
        {

            return await _context.Set<T>()
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByPagination(int page, int pageSize, Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetById(int id, Expression<Func<T, bool>> predicate)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                if (predicate != null)
                {
                    query = query.Where(predicate);
                }
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> UpdateEntity(T entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> CountAsync()
        {
            try
            {
                return await _context.Set<T>().CountAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
