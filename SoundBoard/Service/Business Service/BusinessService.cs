using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Service
{
    public class BusinessService<TEntity, TGetDto, TAddDto, TUpdateDto>
        : IBusinessService<TEntity, TGetDto, TAddDto, TUpdateDto>
        where TEntity : BaseEntity
        where TGetDto : class
        where TAddDto : class
        where TUpdateDto : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        protected BusinessService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<ServiceResponse<List<TGetDto>>> GetAllAsync()
        {
            ServiceResponse<List<TGetDto>> response = new ServiceResponse<List<TGetDto>>();
            try
            {
                var entities = await _repository.GetQueryable().ToListAsync();
                response.Data = _mapper.Map<List<TGetDto>>(entities);
                response.Message = "�l�ments r�cup�r�s avec succ�s";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Erreur lors de la r�cup�ration : {ex.Message}";
            }
            return response;
        }

        public virtual async Task<ServiceResponse<TGetDto>> GetByIdAsync(int id)
        {
            ServiceResponse<TGetDto> response = new ServiceResponse<TGetDto>();
            try
            {
                var entity = await _repository.GetById(id);
                if (entity == null)
                {
                    response.Success = false;
                    response.Message = "�l�ment non trouv�";
                    return response;
                }

                response.Data = _mapper.Map<TGetDto>(entity);
                response.Message = "�l�ment r�cup�r� avec succ�s";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Erreur lors de la r�cup�ration : {ex.Message}";
            }
            return response;
        }

        public virtual async Task<ServiceResponse<TGetDto>> AddAsync(TAddDto addDto)
        {
            ServiceResponse<TGetDto> response = new ServiceResponse<TGetDto>();
            try
            {
                TEntity entity = _mapper.Map<TEntity>(addDto);

                entity.CreationDate= DateTime.Now;
                entity.UpdatedDate= DateTime.Now;

                var addedEntity = await _repository.AddEntity(entity);

                response.Data = _mapper.Map<TGetDto>(addedEntity);

                response.Message = "�l�ment ajout� avec succ�s";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Erreur lors de l'ajout : {ex.Message}";
            }
            return response;
        }

        public virtual async Task<ServiceResponse<TGetDto>> UpdateAsync(
            int id,
            TUpdateDto updateDto
        )
        {
            ServiceResponse<TGetDto> response = new ServiceResponse<TGetDto>();
            try
            {
                var existingEntity = await _repository.GetById(id);
                if (existingEntity == null)
                {
                    response.Success = false;
                    response.Message = "�l�ment non trouv�";
                    return response;
                }

                TEntity entity = _mapper.Map<TEntity>(updateDto);
                entity.UpdatedDate = DateTime.Now;
                var updatedEntity = await _repository.UpdateEntity(entity);

                response.Data = _mapper.Map<TGetDto>(updatedEntity);
                response.Message = "�l�ment mis � jour avec succ�s";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Erreur lors de la mise � jour : {ex.Message}";
            }
            return response;
        }

        public virtual async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                response.Data = await _repository.DeleteEntity(id);
                if (!response.Data)
                {
                    response.Success = false;
                    response.Message = "�l�ment non trouv�";
                    return response;
                }

                response.Message = "�l�ment supprim� avec succ�s";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Erreur lors de la suppression : {ex.Message}";
            }
            return response;
        }
    }
}
