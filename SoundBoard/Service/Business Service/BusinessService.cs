using AutoMapper;
using SoundBoard.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Service
{
    public class BusinessService<TEntity, TGetDto, TAddDto, TUpdateDto> : IBusinessService<TEntity, TGetDto, TAddDto, TUpdateDto>
    where TEntity : class
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
            var response = new ServiceResponse<List<TGetDto>>();
            try
            {
                var entities = await _repository.GetQueryable().ToListAsync();
                response.Data = _mapper.Map<List<TGetDto>>(entities);
                response.Message = "Éléments récupérés avec succès";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Erreur lors de la récupération : {ex.Message}";
            }
            return response;
        }

        public virtual async Task<ServiceResponse<TGetDto>> GetByIdAsync(int id)
        {
            var response = new ServiceResponse<TGetDto>();
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    response.Success = false;
                    response.Message = "Élément non trouvé";
                    return response;
                }

                response.Data = _mapper.Map<TGetDto>(entity);
                response.Message = "Élément récupéré avec succès";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Erreur lors de la récupération : {ex.Message}";
            }
            return response;
        }

        public virtual async Task<ServiceResponse<TGetDto>> AddAsync(TAddDto addDto)
        {
            var response = new ServiceResponse<TGetDto>();
            try
            {
                var entity = _mapper.Map<TEntity>(addDto);
                var addedEntity = await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();

                response.Data = _mapper.Map<TGetDto>(addedEntity);
                response.Message = "Élément ajouté avec succès";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Erreur lors de l'ajout : {ex.Message}";
            }
            return response;
        }

        public virtual async Task<ServiceResponse<TGetDto>> UpdateAsync(int id, TUpdateDto updateDto)
        {
            var response = new ServiceResponse<TGetDto>();
            try
            {
                var existingEntity = await _repository.GetByIdAsync(id);
                if (existingEntity == null)
                {
                    response.Success = false;
                    response.Message = "Élément non trouvé";
                    return response;
                }

                var entity = _mapper.Map<TEntity>(updateDto);
                entity.Id = id;

                var updatedEntity = await _repository.UpdateAsync(entity);
                await _repository.SaveChangesAsync();

                response.Data = _mapper.Map<TGetDto>(updatedEntity);
                response.Message = "Élément mis à jour avec succès";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Erreur lors de la mise à jour : {ex.Message}";
            }
            return response;
        }

        public virtual async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                response.Data = await _repository.DeleteAsync(id);
                if (!response.Data)
                {
                    response.Success = false;
                    response.Message = "Élément non trouvé";
                    return response;
                }

                await _repository.SaveChangesAsync();
                response.Message = "Élément supprimé avec succès";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Erreur lors de la suppression : {ex.Message}";
            }
            return response;
        }

        public virtual async Task<ServiceResponse<bool>> SoftDeleteAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                response.Data = await _repository.SoftDeleteAsync(id);
                if (!response.Data)
                {
                    response.Success = false;
                    response.Message = "Élément non trouvé";
                    return response;
                }

                await _repository.SaveChangesAsync();
                response.Message = "Élément archivé avec succès";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Erreur lors de l'archivage : {ex.Message}";
            }
            return response;
        }
    }
}