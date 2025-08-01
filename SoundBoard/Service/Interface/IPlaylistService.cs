using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Service.Interface
{
    public interface IPlaylistService :
         IBusinessService<SoundEffect, GetSoundFileDto, AddSoundFileDto, UpdateSoundFileDto> { }
    {
        
    }
}