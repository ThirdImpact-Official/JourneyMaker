using Microsoft.AspNetCore.Mvc;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundLibraryController : GenericController<SoundLibrary>
    {
        private readonly ISoundLibraryRepository _library;
        public SoundLibraryController(ISoundLibraryRepository repository) : base(repository)
        {
            _library = repository;
        }
    }
}
