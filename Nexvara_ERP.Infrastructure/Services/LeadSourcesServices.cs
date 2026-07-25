using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
using Nexvara_ERP.Application.Interface.Common;
using Nexvara_ERP.Application.Interface.IRepository;
using Nexvara_ERP.Application.Interface.IServices;
using Nexvara_ERP.Core;
using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Infrastructure.Services
{
    public class LeadSourcesServices : ILeadSourcesServices
    {
        private readonly ILeadSourcesRepository _leadsourcesRepository;
        private readonly IUnitofWork _unitofWork;
        public LeadSourcesServices(ILeadSourcesRepository leadSourcesRepository, IUnitofWork unitofWork)
        {
            _leadsourcesRepository = leadSourcesRepository;
            _unitofWork = unitofWork;
        }
        public async Task<LeadSourcesResponseDto<object>> GetByIdLeadSourcesAsync(int id)
        {
            var response = new LeadSourcesResponseDto<object>();
            if (id <= 0)
            {
                response.Success = false;
                response.Message = SystemMessage.RequiredId;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var res = await _leadsourcesRepository.GetByIdLeadSourcesAsync(id);
            if(res == null)
            {
                response.Success = false;
                response.Message = SystemMessage.RecordNotFound;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var data = new GetLeadSourcesDto
            {
                Id = res.Id,
                Name = res.Name,
                Description = res.Description
            };
            response.Success = true;
            response.Message = SystemMessage.RecordFetchSuccesfully;
            response.Data = data;
            response.StatusCodes = (int)ResponseCodes.Success;
            return response;
        }

        public async Task<PaginationResponseDto<GetLeadSourcesDto>> GetListLeadSourcesAsync(RequestStatusResponse request)
        {
            request.PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            var res = await _leadsourcesRepository.GetListLeadSourcesAsync(request);
            return new PaginationResponseDto<GetLeadSourcesDto>
            {
                Data = res.Data.Select(x => new GetLeadSourcesDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList(),
                PageNumber = res.PageNumber,
                PageSize = res.PageSize,
                TotalPages = res.TotalPages,
                TotalRecords = res.TotalRecords,
                Message = SystemMessage.RecordFetchSuccesfully,
                StatusCodes = (int) ResponseCodes.Success
            };
        }

        public async Task<BaseResponse> SaveAsync(AddLeadSourcesDto dto, string userId)
        {
            var response = new BaseResponse();
            try
            {
                if (dto == null)
                {
                    response.Message = SystemMessage.RequestbodyNull;
                    response.StatusCodes = (int)ResponseCodes.BadRequest;
                    return response;
                }
                var data = new LeadSources
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    CreateAt = DateTime.Now,
                    CreateBy = userId
                    
                };
                await _leadsourcesRepository.SaveAsync(data);
                await _unitofWork.SaveChangesAsync();
                response.Message = SystemMessage.RecordAddSuccessfully;
                response.StatusCodes = (int)ResponseCodes.Success;
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateAsync(UpdateLeadSourcesDto dto, string userId)
        {
            var respone = new BaseResponse();
            if (dto.Id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _leadsourcesRepository.UpdateAsync(dto.Id);
            if (data == null)
            {
                respone.Message = SystemMessage.RecordNotFound;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            if(!data.IsActive)
            {
                respone.Message = SystemMessage.InActiveData;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            data.Name = dto.Name;
            data.Description = dto.Description;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitofWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;

        }

        public async Task<BaseResponse> UpdateStatusAsync(int id, string userId)
        {
            var respone = new BaseResponse();
            if (id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _leadsourcesRepository.UpdateAsync(id);
            if (data == null)
            {
                respone.Message = SystemMessage.RecordNotFound;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            data.IsActive = !data.IsActive;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitofWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }
    }
}
