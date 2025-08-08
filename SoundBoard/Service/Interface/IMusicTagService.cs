using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundBoard.Dto.MusicTag;

namespace SoundBoard.Service.Interface
{
    public interface IMusicTagService : IBusinessService<MusicTag,GetMusicTagDto,AddMusicTagDto,UpdateMusicTagDto>
    {
        
    }
}