using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SoundBoard.Dto.MusicTag;

namespace SoundBoard.Service.Business_Service
{
    /// <summary>
    /// Music tag service
    /// recover the music tags present in the database 
    /// </summary>
    public class MusicTagService : BusinessService<MusicTag, GetMusicTagDto, AddMusicTagDto, UpdateMusicTagDto>, IMusicTagService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public MusicTagService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get Repository
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override IRepository<MusicTag> GetRepository()
        {
            return this.unitOfWork.GetRepository<MusicTag>();
        }
    }
}