using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundBoard.Dto.Tag;

namespace SoundBoard.Service.Interface
{
    public interface IUserTagService
        : IBusinessService<UserTag, GetUserTagDto, AddUserTagDto, UpdateUserTagDto>
    {

    }
}

