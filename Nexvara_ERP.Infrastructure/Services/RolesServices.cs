using Azure.Core;
using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
using Nexvara_ERP.Application.DTOs.Sales.CreateDto;
using Nexvara_ERP.Application.DTOs.Sales.GetDto;
using Nexvara_ERP.Application.DTOs.Sales.UpdateDto;
using Nexvara_ERP.Application.Interface.Common;
using Nexvara_ERP.Application.Interface.IRepository;
using Nexvara_ERP.Application.Interface.IServices;
using Nexvara_ERP.Core;
using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Entity.Master;
using Nexvara_ERP.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Infrastructure.Services
{
    public class RolesServices : IRolesServices
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IUnitofWork _unitofWork;
        public RolesServices(IRolesRepository rolesRepository, IUnitofWork unitofWork)
        {
            _rolesRepository = rolesRepository;
            _unitofWork = unitofWork;
        }
        public async Task<ResponseDepartment<object>> GetByIdDepartmentAsync(int id)
        {
            var response = new ResponseDepartment<object>();
            if (id <= 0)
            {
                response.Success = false;
                response.Message = SystemMessage.RequiredId;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var res = await _rolesRepository.GetByIdDepartmentAsync(id);
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
                Id = res.Id,
                DepartmentCode = res.DepartmentCode,
                RoleName = res.Role.Name,
                DepartmentName = res.DepartmentName,
                Status = res.Status,
                Description = res.Description,
                IsActive = res.IsActive,
            };
            response.Success = true;
            response.Message = SystemMessage.RecordFetchSuccesfully;
            response.Data = data;
            response.StatusCodes = (int)ResponseCodes.Success;
            return response;
        }

        public async Task<ResponseDesignation<object>> GetByIdDesignationAsync(int id)
        {
            var response = new ResponseDesignation<object>();
            if (id <= 0)
            {
                response.Success = false;
                response.Message = SystemMessage.RequiredId;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var res = await _rolesRepository.GetByIdDesignationAsync(id);
            if (res == null)
            {
                response.Success = false;
                response.Message = SystemMessage.RecordNotFound;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var data = new GetDesignation
            {
                Id = res.Id,
                DepartmentName=res.Department.DepartmentName,
                DesignationCode=res.DesignationCode,
                DesignationName=res.DesignationName,
                Status=res.Status,
                Description = res.Description,
                IsActice=res.IsActive
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
            var res = await _rolesRepository.GetListDepartmentAsync(request);
            return new PaginationResponseDto<GetDepartment>
            {
                Data = res.Data.Select(x => new GetDepartment
                {
                    Id = x.Id,
                    DepartmentCode = x.DepartmentCode,
                    RoleName = x.Role.Name,
                    DepartmentName = x.DepartmentName,
                    Status = x.Status,
                    Description = x.Description,
                    IsActive = x.IsActive,
                }).ToList(),
                PageNumber = res.PageNumber,
                PageSize = res.PageSize,
                TotalPages = res.TotalPages,
                TotalRecords = res.TotalRecords,
                Message = SystemMessage.RecordFetchSuccesfully,
                StatusCodes = (int)ResponseCodes.Success
            };
        }

        public async Task<PaginationResponseDto<GetDesignation>> GetListDesignationAsync(RequestStatusResponse request)
        {
            request.PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            var res = await _rolesRepository.GetListDesignationAsync(request);
            return new PaginationResponseDto<GetDesignation>
            {
                Data = res.Data.Select(x => new GetDesignation
                {
                    Id = x.Id,
                    DepartmentName = x.Department.DepartmentName,
                    DesignationCode = x.DesignationCode,
                    DesignationName = x.DesignationName,
                    Status = x.Status,
                    Description = x.Description,
                    IsActice = x.IsActive

                }).ToList(),
                PageNumber = res.PageNumber,
                PageSize = res.PageSize,
                TotalPages = res.TotalPages,
                TotalRecords = res.TotalRecords,
                Message = SystemMessage.RecordFetchSuccesfully,
                StatusCodes = (int)ResponseCodes.Success
            };
        }

        public async Task<BaseResponse> SaveDepartmentAsync(CreateDepartment dto, string userId)
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
                var lastCode = await _rolesRepository.GetLastIdDepartmentAsync();
                int lastSequence = 0;

                if (!string.IsNullOrWhiteSpace(lastCode))
                {
                    string numberPart = new string(lastCode.Where(char.IsDigit).ToArray());

                    if (!string.IsNullOrEmpty(numberPart))
                        lastSequence = int.Parse(numberPart);
                }

                string newCode = GenrateCode.GenerateDepartmentCode(dto.DepartmentName, lastSequence);
                var data = new Department
                {
                    DepartmentCode = newCode,
                    RoleId = dto.RoleId,
                    DepartmentName = dto.DepartmentName,
                    Status = CreateStatus.Pending.ToString(),
                    Description = dto.Description,
                    IsActive = true,
                    CreateAt = DateTime.Now,
                    CreateBy = userId

                };
                await _rolesRepository.SaveDepartmentAsync(data);
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

        public async Task<BaseResponse> SaveDesignationAsync(CreateDesignation dto, string userId)
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
                var lastCode = await _rolesRepository.GetLastIdDesignationAsync();
                int lastSequence = 0;

                if (!string.IsNullOrWhiteSpace(lastCode))
                {
                    string numberPart = new string(lastCode.Where(char.IsDigit).ToArray());

                    if (!string.IsNullOrEmpty(numberPart))
                        lastSequence = int.Parse(numberPart);
                }

                string newCode = GenrateCode.GenerateDepartmentCode(dto.DesignationName, lastSequence);
                var data = new Designation
                {
                    DepartmentId = dto.DepartmentId,
                    DesignationCode = newCode,
                    DesignationName = dto.DesignationName,
                    Status = CreateStatus.Pending.ToString(),
                    Description = dto.Description,
                    IsActive = true,
                    CreateAt = DateTime.Now,
                    CreateBy = userId

                };
                await _rolesRepository.SaveDesignationAsync(data);
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

        public async Task<BaseResponse> UpdateDepartmentAsync(UpdateDepartment dto, string userId)
        {

            var respone = new BaseResponse();
            if (dto.Id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _rolesRepository.UpdateDepartmentAsync(dto.Id);     
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
            if (data.DepartmentName.ToLower().Trim() != dto.DepartmentName.ToLower().Trim())
            {
                var lastCode = await _rolesRepository.GetLastIdDepartmentAsync();
                int lastSequence = 0;

                if (!string.IsNullOrWhiteSpace(lastCode))
                {
                    string numberPart = new string(lastCode.Where(char.IsDigit).ToArray());

                    if (!string.IsNullOrEmpty(numberPart))
                        lastSequence = int.Parse(numberPart);
                }

                string newCode = GenrateCode.GenerateDepartmentCode(dto.DepartmentName, lastSequence);
                data.DepartmentCode = newCode;
                data.DepartmentName = dto.DepartmentName;
            }

            data.RoleId = dto.RoleId;
            data.Status = dto.Status;
            data.Description = dto.Description;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitofWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }

        public async Task<BaseResponse> UpdateDepartmentStatusAsync(int id, string userId)
        {

            var respone = new BaseResponse();
            if (id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _rolesRepository.UpdateDepartmentAsync(id);
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

        public async Task<BaseResponse> UpdateDesignationAsync(UpdateDesignation dto, string userId)
        {
            var respone = new BaseResponse();
            if (dto.Id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _rolesRepository.UpdateDesignationAsync(dto.Id);
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
            if (data.DesignationName.ToLower().Trim() != dto.DesignationName.ToLower().Trim())
            {
                var lastCode = await _rolesRepository.GetLastIdDesignationAsync();
                int lastSequence = 0;

                if (!string.IsNullOrWhiteSpace(lastCode))
                {
                    string numberPart = new string(lastCode.Where(char.IsDigit).ToArray());

                    if (!string.IsNullOrEmpty(numberPart))
                        lastSequence = int.Parse(numberPart);
                }

                string newCode = GenrateCode.GenerateDepartmentCode(dto.DesignationName, lastSequence);
                data.DesignationCode = newCode;
                data.DesignationName = dto.DesignationName;
            }

            data.DepartmentId = dto.DepartmentId;
            data.Status = dto.Status;
            data.Description = dto.Description;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitofWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }

        public async Task<BaseResponse> UpdateDesignationStatusAsync(int id, string userId)
        {
            var respone = new BaseResponse();
            if (id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _rolesRepository.UpdateDesignationAsync(id);
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
