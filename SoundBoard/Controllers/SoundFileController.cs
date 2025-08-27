
using Microsoft.AspNetCore.Mvc;

using SoundBoard.Dto.SoundFile;


namespace SoundBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundFileController : GenericController<Models.SoundEffect,GetSoundFileDto,AddSoundFileDto,UpdateSoundFileDto>
    {
        private readonly ISoundFileService _soundFileRepository;
        public SoundFileController(ISoundFileService service) : base(service)
        {
            _soundFileRepository = service;
        }

        
    }
}
