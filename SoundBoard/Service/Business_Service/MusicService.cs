using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SoundBoard.Dto.MusicFile;

namespace SoundBoard.Service.Business_Service
{
    public class MusicService
        : BusinessService<Music, GetMusicFileDto, AddMusicFileDto, UpdateMusicFileDto>,
            IMusicService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the MusicService class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work that provides access to repositories.</param>
        /// <param name="mapper">The mapper used for object-object mapping.</param>
        public MusicService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
            // The base constructor is called to initialize the base class with the provided unitOfWork and mapper.
            // No additional initialization logic is added here for the MusicService class.
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        protected override IRepository<Music> GetRepository()
        {
             return this.unitOfWork.GetRepository<Music>();
        }
    }
}
