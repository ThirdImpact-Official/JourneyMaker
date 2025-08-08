using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SoundBoard.Models;

namespace SoundBoard.Service.Interface
{
    public interface IBusinessService<TEntity, TGetDto, TAddDto, TUpdateDto>
        where TEntity : BaseEntity
        where TGetDto : class
        where TAddDto : class
        where TUpdateDto : class
    {
        /// <summary>
        /// Get all Entities 
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<List<TGetDto>>> GetAllAsync();
        /// <summary>
        /// Get all Entities by page 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<Pagination<TGetDto>> GetPageAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>>? predicate = null
        );
        /// <summary>
        /// Get an Entity by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<TGetDto>> GetByIdAsync(int id);
        /// <summary>
        /// Add an Entity 
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task<ServiceResponse<TGetDto>> AddAsync(TAddDto addDto);
        /// <summary>
        /// Update an Entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task<ServiceResponse<TGetDto>> UpdateAsync(int id, TUpdateDto updateDto);
        /// <summary>
        /// Delete an Entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<TGetDto>> DeleteAsync(int id);
    }
}
