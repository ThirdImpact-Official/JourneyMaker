using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SoundBoard.Dto.SoundFile;

namespace SoundBoard.Service.Business_Service
{
    public class SoundFileService
        : BusinessService<SoundEffect, GetSoundFileDto, AddSoundFileDto, UpdateSoundFileDto>,
            ISoundFileService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SoundFileService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}
