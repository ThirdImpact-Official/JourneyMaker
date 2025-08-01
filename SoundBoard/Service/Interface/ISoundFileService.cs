using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundBoard.Dto.SoundFile;

namespace SoundBoard.Service.Interface
{
    public interface ISoundFileService
        : IBusinessService<SoundEffect, GetSoundFileDto, AddSoundFileDto, UpdateSoundFileDto> { }
}
