using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
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
        private IUnitOfWork unitOfWork;

        protected BusinessService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BusinessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
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

                entity.CreationDate = DateTime.Now;
                entity.UpdatedDate = DateTime.Now;

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

        public virtual async Task<ServiceResponse<TGetDto>> DeleteAsync(int id)
        {
            ServiceResponse<TGetDto> response = new ServiceResponse<TGetDto>();
            try
            {
                response.Data = _mapper.Map<TGetDto>(await _repository.DeleteEntity(id));
                if (response.Data is null)
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

        /// <summary>
        /// Get all Entities by page
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<Pagination<TGetDto>> GetPageAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>>? predicate = null
        )
        {
            Pagination<TGetDto> response = new Pagination<TGetDto>();
            try
            {
                //verification
                pageNumber = Math.Max(1, pageNumber);
                pageSize = Math.Max(1, pageSize);

                //my query
                IQueryable<TEntity> query = _repository.GetQueryable();
                if (predicate != null)
                {
                    query = query.Where(predicate);
                }

                //pageCount
                int pageCount = await query.CountAsync();

                int totalPage = (int)Math.Ceiling((double)pageCount / pageSize);

                List<TEntity> getEnttities = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                //operation
                response.Data = _mapper.Map<List<TGetDto>>(getEnttities);
                response.Message = "�l�ments r�cup�r�s avec succ�s";
                response.Success = true;
                response.PageNumber = pageNumber;
                response.PageSize = pageSize;
                response.TotalPage = totalPage;
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
