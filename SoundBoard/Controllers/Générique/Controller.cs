using Microsoft.AspNetCore.Mvc;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TEntity, TGetDto, TAddDto, TUpdateDto> : ControllerBase
        where TEntity : BaseEntity
        where TGetDto : class
        where TAddDto : class
        where TUpdateDto : class
    {
        private IBusinessService<TEntity, TGetDto, TAddDto, TUpdateDto> _bService;

        public GenericController(IBusinessService<TEntity, TGetDto, TAddDto, TUpdateDto> bServerice)
        {
            _bService = bServerice;
        }

        /// <summary>
        /// Get all Entities
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<Pagination<TGetDto>>> GetPage(int pageNumber, int pageSize)
        {
            try
            {
                Pagination<TGetDto> response = await _bService.GetPageAsync(
                    pageNumber,
                    pageSize,
                    null
                );

                return HttpManager.HandleRequest(response as Pagination<TGetDto>);
            }
            catch (System.Exception exception)
            {
                return await HttpManager.BadPageError<TGetDto>(exception);
            }
        }

        /// <summary>
        /// Get an Entity by its Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TGetDto>>> GetById(int Id)
        {
            try
            {
                ServiceResponse<TGetDto> response = await _bService.GetByIdAsync(Id);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (System.Exception exception)
            {
                return await HttpManager.BadError<TGetDto>(exception);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<TGetDto>>> AddEntity(
            [FromBody] TAddDto Entity
        )
        {
            try
            {
                ServiceResponse<TGetDto> response = await _bService.AddAsync(Entity);
                return HttpManager.HandleRequest(response);
            }
            catch (System.Exception exception)
            {
                return await HttpManager.BadError<TGetDto>(exception);
            }
        }

        /// <summary>
        /// Update an Entity
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<ServiceResponse<TGetDto>>> UpdateEntity(
            int id,
            [FromBody] TUpdateDto Entity
        )
        {
            try
            {
                ServiceResponse<TGetDto> response = await _bService.UpdateAsync(id, Entity);
                return HttpManager.HandleRequest(response);
            }
            catch (System.Exception exception)
            {
                return await HttpManager.BadError<TGetDto>(exception);
            }
        }

        /// <summary>
        /// Delete an Entity
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<ActionResult<ServiceResponse<TGetDto>>> Delete(int Id)
        {
            try
            {
                ServiceResponse<TGetDto> response = await _bService.DeleteAsync(Id);
                return HttpManager.HandleRequest(response);
            }
            catch (System.Exception exception)
            {
                return await HttpManager.BadError<TGetDto>(exception);
            }
        }
    }
}
