using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SoundBoard.Dto.MusicCycles;
using SoundBoard.Models;

namespace SoundBoard.Service.Business_Service
{
    public class MusicCycleService
        : BusinessService<MusicCycles, GetMusicCycleDto, AddMusicCyclesDto, UpdateMusicCyclesDto>, IMusicCycleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public MusicCycleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}