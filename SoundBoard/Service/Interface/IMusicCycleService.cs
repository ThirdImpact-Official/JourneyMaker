using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundBoard.Dto.MusicCycles;

namespace SoundBoard.Service.Interface
{
    public interface IMusicCycleService
        : IBusinessService<
            MusicCycles,
            GetMusicCycleDto,
            AddMusicCyclesDto,
            UpdateMusicCyclesDto
        > { }
}
