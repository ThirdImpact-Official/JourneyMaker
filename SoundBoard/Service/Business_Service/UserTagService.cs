using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SoundBoard.Dto.Tag;

namespace SoundBoard.Service.Business_Service
{
    /// <summary>
    /// Tag service interface 
    /// </summary>
    public class UserTagService
        : BusinessService<Models.UserTag, GetUserTagDto, AddUserTagDto, UpdateUserTagDto>,
        IUserTagService
    {

        /// <summary>
        /// Unit of work 
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public UserTagService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        protected override IRepository<UserTag> GetRepository()
        {
            return this.unitOfWork.GetRepository<Models.UserTag>();
        }
    }
}
