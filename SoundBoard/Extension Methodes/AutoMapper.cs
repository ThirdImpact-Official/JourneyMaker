using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SoundBoard.Dto.MusicCycles;
using SoundBoard.Dto.MusicItem;
using SoundBoard.Models;

namespace SoundBoard.Extension_Methodes
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // the music items
            MapperGeneric<
                MusicCycleItem,
                GetMusicCycleItemDto,
                AddMusicCyclesItemDto,
                UpdateMusicCycleItemDto
            >();

            // the music cycles
            MapperGeneric<
                MusicCycles,
                GetMusicCycleDto,
                AddMusicCyclesDto,
                UpdateMusicCyclesDto
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
