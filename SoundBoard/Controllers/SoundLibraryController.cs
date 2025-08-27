using Microsoft.AspNetCore.Mvc;
using SoundBoard.Dto.SoundFile;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundLibraryController : GenericController<Models.SoundEffectLibrary,GetSoundFileDto,AddSoundFileDto,UpdateSoundFileDto>
    {
        private readonly ISoundFileService _service;
        public SoundLibraryController(ISoundFileService service) : base((IBusinessService<SoundEffectLibrary, GetSoundFileDto, AddSoundFileDto, UpdateSoundFileDto>)service)
        {
            _service = service;
        }
    }
}
