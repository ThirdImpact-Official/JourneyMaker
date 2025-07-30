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
        Task<ServiceResponse<List<TGetDto>>> GetAllAsync();
        Task<Pagination<TGetDto>> GetPageAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>>? predicate = null
        );
        Task<ServiceResponse<TGetDto>> GetByIdAsync(int id);
        Task<ServiceResponse<TGetDto>> AddAsync(TAddDto addDto);
        Task<ServiceResponse<TGetDto>> UpdateAsync(int id, TUpdateDto updateDto);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}
