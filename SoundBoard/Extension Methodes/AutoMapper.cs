using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace SoundBoard.Extension_Methodes
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapperGeneric<
                MusicCycleItem,
                MusicCycleItemDto,
                MusicCycleItemDto,
                MusicCycleItemDto
            >();
            MapperGeneric<
                MusicCycleItem,
                MusicCycleItemDto,
                MusicCycleItemDto,
                MusicCycleItemDto
            >();
        }

        public void MapperGeneric<TEntity, TGetDto, TAddDto, TUpdateDto>()
            where TEntity : class
            where TGetDto : class
            where TAddDto : class
            where TUpdateDto : class
        {
            CreateMap<TEntity, TGetDto>();
            CreateMap<TUpdateDto, TEntity>();
            CreateMap<TAddDto, TEntity>();
        }
    }
}
