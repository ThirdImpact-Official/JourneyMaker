
using Microsoft.AspNetCore.Mvc;

using SoundBoard.Dto.SoundFile;


namespace SoundBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundFileController : GenericController<Models.SoundEffect,GetSoundFileDto,AddSoundFileDto,UpdateSoundFileDto>
    {
        
        public SoundFileController() : base()
        {
            _soundFileRepository = repository;
        }

        
    }
}
