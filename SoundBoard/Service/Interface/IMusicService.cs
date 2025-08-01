using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundBoard.Dto.MusicFile;

namespace SoundBoard.Service.Interface
{
    public interface IMusicService
        : IBusinessService<Music, GetMusicFileDto, AddMusicFileDto, UpdateMusicFileDto> { }
}
