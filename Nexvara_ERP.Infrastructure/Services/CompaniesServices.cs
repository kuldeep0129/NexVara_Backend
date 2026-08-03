using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
using Nexvara_ERP.Application.Interface.Common;
using Nexvara_ERP.Application.Interface.IRepository;
using Nexvara_ERP.Application.Interface.IServices;
using Nexvara_ERP.Core;
using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Entity;
using Nexvara_ERP.Infrastructure.common;
using Nexvara_ERP.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Infrastructure.Services
{
    public class CompaniesServices : ICompaninesServices
    {
        private readonly ICompaniesRepositry _companiesRepositry;
        private readonly IUnitofWork _unitofWork;
        public CompaniesServices(ICompaniesRepositry companiesRepositry, IUnitofWork unitofWork)
        {
            _companiesRepositry = companiesRepositry;
            _unitofWork = unitofWork;
        }
        public async Task<CompanyResponseDto<object>> GetByIdCompanyAsync(int id)
        {
            var response = new CompanyResponseDto<object>();
            if (id <= 0)
            {
                response.Success = false;
                response.Message = SystemMessage.RequiredId;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var res = await _companiesRepositry.GetByCompanyIdAsync(id);
            if (res == null)
            {
                response.Success = false;
                response.Message = SystemMessage.RecordNotFound;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var data = new Getcompinesdto
            {
                Id = res.Id,
                CompanyName = res.CompanyName,
                IndustryId = res.IndustryId,
                CompanySizeId = res.CompanySizeId,
                Website = res.Website,
                Email = res.Email,
                Phone = res.Phone,
                CountryId = res.CountryId,
                StateId = res.StateId,
                CityId = res.CityId,
                Address = res.Address,
                PinCode = res.PinCode,
                GSTNumber = res.GSTNumber,
                PANNumber = res.PANNumber,
            };
            response.Success = true;
            response.Message = SystemMessage.RecordFetchSuccesfully;
            response.Data = data;
            response.StatusCodes = (int)ResponseCodes.Success;
            return response;
        }
        public async Task<PaginationResponseDto<Getcompinesdto>> GetListCompanyAsync(RequestStatusResponse request)
        {
            request.PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            var res = await _companiesRepositry.GetListCompaniesAsync(request);
            return new PaginationResponseDto<Getcompinesdto>
            {
                Data = res.Data.Select(x => new Getcompinesdto
                {
                    Id=x.Id,
                    CompanyName = x.CompanyName,
                    IndustryId = x.IndustryId,
                    CompanySizeId = x.CompanySizeId,
                    Website = x.Website,
                    Email = x.Email,
                    Phone = x.Phone,
                    CountryId = x.CountryId,
                    StateId = x.StateId,
                    CityId = x.CityId,
                    Address = x.Address,
                    PinCode = x.PinCode,
                    GSTNumber = x.GSTNumber,
                    PANNumber = x.PANNumber,
                }).ToList(),
                PageNumber = res.PageNumber,
                PageSize = res.PageSize,
                TotalPages = res.TotalPages,
                TotalRecords = res.TotalRecords,
                Message = SystemMessage.RecordFetchSuccesfully,
                StatusCodes = (int)ResponseCodes.Success
            };
        }
        public async Task<BaseResponse> SaveAsync(addcompaniesdto dto, string userId)
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
                var data = new Company
                {
                    CompanyName = dto.CompanyName,
                    IndustryId = dto.IndustryId,
                    CompanySizeId = dto.CompanySizeId,
                    Website = dto.Website,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    CountryId = dto.CountryId,
                    StateId = dto.StateId,
                    CityId = dto.CityId,
                    Address = dto.Address,
                    PinCode = dto.PinCode,
                    GSTNumber = dto.GSTNumber,
                    PANNumber = dto.PANNumber,
                    CreateAt = DateTime.Now,
                    CreateBy = userId

                };
                await _companiesRepositry.SaveAsync(data);
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

        public async Task<BaseResponse> UpdateAsync(Updatecompaniesdto dto, string userId)
        {
            var respone = new BaseResponse();
            if (dto.Id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _companiesRepositry.UpdateAsync(dto.Id);
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
            data.CompanyName = dto.CompanyName;
            data.IndustryId = dto.IndustryId;
            data.CompanySizeId = dto.CompanySizeId;
            data.Website = dto.Website;
            data.Email = dto.Email;
            data.Phone = dto.Phone;
            data.CountryId = dto.CountryId;
            data.StateId = dto.StateId;
            data.CityId = dto.CityId;
            data.Address = dto.Address;
            data.PinCode = dto.PinCode;
            data.GSTNumber = dto.GSTNumber;
            data.PANNumber = dto.PANNumber;
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
            var data = await _companiesRepositry.UpdateAsync(id);
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
