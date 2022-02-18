﻿using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.SubjectType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.SubjectTypeService
{
    public class SubjectTypeService : ISubjectTypeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SubjectTypeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetSubjectTypeDto>> AddSubjectType(AddSubjectTypeDto createSubjectType)
        {
            try
            {
                await _unitOfWork.SubjectTypes.Create(_mapper.Map<SubjectType>(createSubjectType));
                if (await SaveChange())
                {
                    return new ServiceResponse<GetSubjectTypeDto> { Success = true, Message = "Add Subject Type Success" };
                }
                else
                {
                    return new ServiceResponse<GetSubjectTypeDto> { Success = false, Message = "Error when create new Subject Type" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectTypeDto> { Success = false, Message = ex.Message };
            }
        }
        public async Task<ServiceResponse<SubjectType>> Delete(SubjectType deleteSubjectType)
        {
            try
            {
                var subjectTypeFromDB = await Find(x => x.Id == 1.ToString());
                if (subjectTypeFromDB != null)
                {
                    _unitOfWork.SubjectTypes.Delete(deleteSubjectType);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<SubjectType> { Success = false, Message = "Error when delete Subject Type" };
                    }
                    return new ServiceResponse<SubjectType> { Success = true, Message = "Delete Subject Type Success" };
                }
                else
                {
                    return new ServiceResponse<SubjectType> { Success = false, Message = "Not Found Subject Type" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<SubjectType> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<GetSubjectTypeDto>> DeleteSubjectType(SubjectType deleteSubjectType)
        {
            try
            {
                _unitOfWork.SubjectTypes.Delete(deleteSubjectType);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetSubjectTypeDto> { Success = false, Message = "Error when delete Subject Type" };
                }
                return new ServiceResponse<GetSubjectTypeDto> { Success = true, Message = "Delete Subject Type Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectTypeDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetSubjectTypeDto> Find(Expression<Func<SubjectType, bool>> expression = null, List<string> includes = null)
            => _mapper.Map<GetSubjectTypeDto>(await _unitOfWork.SubjectTypes.FindByConditionAsync(expression, includes));


        public async Task<ICollection<GetSubjectTypeDto>> FindAll(Expression<Func<SubjectType, bool>> expression = null, Func<IQueryable<SubjectType>, IOrderedQueryable<SubjectType>> orderBy = null, List<string> includes = null)
        => _mapper.Map<ICollection<GetSubjectTypeDto>>(await _unitOfWork.SubjectTypes.FindAllAsync(expression, orderBy, includes));

        public async Task<ServiceResponse<ICollection<GetSubjectTypeDto>>> GetAllSubjectType(Expression<Func<SubjectType, bool>> expression = null, Func<IQueryable<SubjectType>, IOrderedQueryable<SubjectType>> orderBy = null, List<string> includes = null)
        {
            var listSubjectTypeFromDb = _mapper.Map<ICollection<GetSubjectTypeDto>>(await _unitOfWork.SubjectTypes.FindAllAsync(expression, orderBy, includes));
            if (listSubjectTypeFromDb != null)
            {
                return new() { Success = true, Message = "Get list Subject Type Success", Data = listSubjectTypeFromDb };
            }
            return new() { Message = "List Subject Type is not exist", Success = false };
        }

        public async Task<ServiceResponse<GetSubjectTypeDto>> GetSubjectTypeByCondition(Expression<Func<SubjectType, bool>> expression = null, List<string> includes = null)
        {
            var subjectTypeFromDb = _mapper.Map<GetSubjectTypeDto>(await _unitOfWork.SubjectTypes.FindByConditionAsync(expression, includes));
            if (subjectTypeFromDb != null)
            {
                return new() { Success = true, Message = "Get Subject Type Success", Data = subjectTypeFromDb };
            }
            return new() { Message = "Subject Type is not exist", Success = false };
        }

        public async Task<bool> IsExisted(Expression<Func<SubjectType, bool>> expression = null)
        {
            var isExist = await _unitOfWork.SubjectTypes.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.SubjectTypes.Save();
        public async Task<ServiceResponse<GetSubjectTypeDto>> UpdateSubjectType(UpdateSubjectTypeDto updateSubjectType)
        {
            try
            {
                var task = _mapper.Map<SubjectType>(updateSubjectType);
                _unitOfWork.SubjectTypes.Update(task);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetSubjectTypeDto> { Success = false, Message = "Error when update Subject Type" };
                }
                return new ServiceResponse<GetSubjectTypeDto> { Success = true, Message = "Update Subject Type Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetSubjectTypeDto> { Success = false, Message = ex.Message };
            }
        }
    }
}