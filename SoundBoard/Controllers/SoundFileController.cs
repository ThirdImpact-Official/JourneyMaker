using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundBoard.Repository.Interface;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundFileController : GenericController<SoundFile>
    {
        private readonly ISoundFileRepository _soundFileRepository;
        public SoundFileController(ISoundFileRepository repository) : base(repository)
        {
            _soundFileRepository = repository;
        }
    }
}
