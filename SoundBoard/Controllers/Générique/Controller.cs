using Microsoft.AspNetCore.Mvc;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly IRepository<T> _repository;

        public GenericController(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<T>>> Get(int pageNumber, int pageSize)
        {
            return Ok(await _repository.GetAllByPagination(pageNumber,pageSize));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<T>>> GetById(int Id)
        {
            return Ok(await _repository.GetById(Id));
        }

        [HttpPost("Create")]
        public async Task<ActionResult> AddEntity([FromBody] T Entity)
        {
            await _repository.AddEntity(Entity);
            return NoContent();
        }
        [HttpPut("update")]
        public async Task<ActionResult> UpdateEntity([FromBody] T Entity)
        {
            await _repository.UpdateEntity(Entity);
            return NoContent();
        }
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _repository.DeleteEntity(Id);
            return NoContent();
        }
    }
}
