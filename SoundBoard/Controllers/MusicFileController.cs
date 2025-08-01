using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SoundBoard.Dto.MusicFile;

namespace SoundBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicFileController
        : GenericController<Models.Music, GetMusicFileDto, AddMusicFileDto, UpdateMusicFileDto>
    {

        private readonly IMusicFileService _musicFileService;
        public MusicFileController( IMusicFileService musicFileService)
            : base(repository) { }
    }
}
