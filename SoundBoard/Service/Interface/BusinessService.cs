namespace SoundBoard.Service.Interface
{
    public interface IBusinessService<TEntity, TGetDto,TAddDto,TUpdateDto>
    where TEntity : class
    where TGetDto : class
    where TAddDto : class
    where TUpdateDto : class
    {
        Task<ServiceResponse<List<TGetDto>>> GetAllAsync();
        Task<ServiceResponse<TGetDto>> GetByIdAsync(int id);
        Task<ServiceResponse<TGetDto>> AddAsync(TAddDto addDto);
        Task<ServiceResponse<TGetDto>> UpdateAsync(int id, TUpdateDto updateDto);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
        Task<ServiceResponse<bool>> SoftDeleteAsync(int id);
    }
}
