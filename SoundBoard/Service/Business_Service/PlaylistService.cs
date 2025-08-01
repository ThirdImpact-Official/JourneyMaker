using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SoundBoard.Dto.Palylist;

namespace SoundBoard.Service.Business_Service
{
    public class PlaylistService
        : BusinessService<Playlist, GetPlaylistDto, AddPlaylistDto, UpdatePlaylistDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PlaylistService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}
