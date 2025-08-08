using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundBoard.Dto.Palylist;
using SoundBoard.Dto.SoundFile;

namespace SoundBoard.Service.Interface
{
    public interface IPlaylistService
        : IBusinessService<Playlist, GetPlaylistDto, AddPlaylistDto, UpdatePlaylistDto> { }
}
