using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
using Nexvara_ERP.Application.Interface.Common;
using Nexvara_ERP.Application.Interface.IRepository;
using Nexvara_ERP.Application.Interface.IServices;
using Nexvara_ERP.Core;
using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Entity;
using Nexvara_ERP.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Infrastructure.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepositry _departmentRepositry;
        private readonly IUnitofWork _unitofWork;

        public DepartmentServices(IDepartmentRepositry departmentRepositry, IUnitofWork unitofWork)
        {
            _departmentRepositry = departmentRepositry;
            _unitofWork = unitofWork;
        }
        public async Task<DepatmentDto<object>> GetByIdDepartmentAsync(int id)
        {
            var response = new DepatmentDto<object>();
            if (id <= 0)
            {
                response.Success = false;
                response.Message = SystemMessage.RequiredId;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var res = await _departmentRepositry.GetByDepartmentAsync(id);
            if (res == null)
            {
                response.Success = false;
                response.Message = SystemMessage.RecordNotFound;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var data = new GetDepartment
            {
                DepartmentId = res.DepartmentId,
                DepartmentCode = res.DepartmentCode,
                DepartmentName = res.DepartmentName,
                Description = res.Description,
                RoleId = res.RoleId,
                IsHeadOffice = res.IsHeadOffice,
                Status = res.Status,                
            };
            response.Success = true;
            response.Message = SystemMessage.RecordFetchSuccesfully;
            response.Data = data;
            response.StatusCodes = (int)ResponseCodes.Success;
            return response;
        }
        public async Task<PaginationResponseDto<GetDepartment>> GetListDepartmentAsync(RequestStatusResponse request)
        {
            request.PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            var res = await _departmentRepositry.GetListDepartmentAsync(request);
            return new PaginationResponseDto<GetDepartment>
            {
                Data = res.Data.Select(x => new GetDepartment
                {
                    DepartmentId = x.DepartmentId,
                    DepartmentCode = x.DepartmentCode,
                    DepartmentName = x.DepartmentName,
                    Description = x.Description,
                    RoleId = x.RoleId,
                    IsHeadOffice = x.IsHeadOffice,
                    Status = x.Status,
                }).ToList(),
                PageNumber = res.PageNumber,
                PageSize = res.PageSize,
                TotalPages = res.TotalPages,
                TotalRecords = res.TotalRecords,
                Message = SystemMessage.RecordFetchSuccesfully,
                StatusCodes = (int)ResponseCodes.Success
            };
        }
        public async Task<BaseResponse> SaveAsync(AddDepartmentDto dto, String UserId)
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
                var data = new Department
                {
                    DepartmentCode = dto.DepartmentCode,
                    DepartmentName = dto.DepartmentName,
                    Description = dto.Description,
                    RoleId = dto.RoleId,
                    IsHeadOffice = dto.IsHeadOffice,
                    Status = dto.Status,
                    
                    CreateAt = DateTime.Now,
                    CreateBy = UserId

                };
                await _departmentRepositry.SaveAsync(data);
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
        public async Task<BaseResponse> UpdateAsync(UpdateDepartmentDto dto, String UserId)
        {
            var respone = new BaseResponse();
            if (dto.DepartmentId <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _departmentRepositry.UpdateAsync(dto.DepartmentId);
            if (data == null)
            {
                respone.Message = SystemMessage.RecordNotFound;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            if (!data.IsActive)
            {
                respone.Message = SystemMessage.InActiveData;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            data.DepartmentCode = dto.DepartmentCode;
            data.DepartmentName = dto.DepartmentName;
            data.Description = dto.Description;
            data.RoleId = dto.RoleId;
            data.IsHeadOffice = dto.IsHeadOffice;
            data.Status = dto.Status;
           
            data.ModifyBy = UserId;
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
            var data = await _departmentRepositry.UpdateAsync(id);
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
