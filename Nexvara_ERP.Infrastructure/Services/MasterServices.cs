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
using Microsoft.EntityFrameworkCore;
using Nexvara_ERP.Infrastructure.common;
using Nexvara_ERP.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Infrastructure.Services
{
    public class MasterServices : IMasterServices
    {
        private readonly IMasterRepository _masterRepository;
        private readonly IUnitofWork _unitOfWork;
        public MasterServices(IMasterRepository masterRepository, IUnitofWork unitOfWork)
        {
            _masterRepository = masterRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddressResponseDto<object>> GetByIdAddressAsync(int id)
        {
            var response = new AddressResponseDto<object>();
            if (id <= 0)
            {
                response.success = false;
                response.Message = SystemMessage.RequiredId;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var res = await _masterRepository.GetByIdAddressAsync(id);
            if (res == null)
            {
                response.success = false;
                response.Message = SystemMessage.RecordNotFound;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var data = new GetAddress
            {
                Id = res.Id,
                AddressLine1 = res.AddressLine1,
                AddressLine2 = res.AddressLine2,
                CityName = res.City.Name,
                StateName = res.City.State.Name,
                CountryName = res.City.State.Country.Name,
                PinCode = res.City.PinCode,
                Remark = res.Remark,
                IsActice = res.IsActive
            };
            response.success = true;
            response.Message = SystemMessage.RecordFetchSuccesfully;
            response.Data = data;
            response.StatusCodes = (int)ResponseCodes.Success;
            return response;

        }

        public async Task<CityResponseDto<object>> GetByIdCityAsync(int id)
        {

            var response = new CityResponseDto<object>();
            if (id <= 0)
            {
                response.success = false;
                response.Message = SystemMessage.RequiredId;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var res = await _masterRepository.GetByIdCityAsync(id);
            if (res == null)
            {
                response.success = false;
                response.Message = SystemMessage.RecordNotFound;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var data = new GetCity
            {
                Id = res.Id,
                StateName = res.State.Name,
                Name = res.Name,
                Description = res.Description,
                PinCode = res.PinCode,
                IsActive = res.IsActive,
            };
            response.success = true;
            response.Message = SystemMessage.RecordFetchSuccesfully;
            response.Data = data;
            response.StatusCodes = (int)ResponseCodes.Success;
            return response;
        }

        public async Task<CountryResponseDto<object>> GetByIdCountryAsync(int id)
        {
            var response = new CountryResponseDto<object>();
            if (id <= 0)
            {
                response.success = false;
                response.Message = SystemMessage.RequiredId;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var res = await _masterRepository.GetByIdCountryAsync(id);
            if (res == null)
            {
                response.success = false;
                response.Message = SystemMessage.RecordNotFound;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var data = new GetCountry
            {
                Id = res.Id,
                Name = res.Name,
                Description = res.Description,
                IsActive = res.IsActive,
            };
            response.success = true;
            response.Message = SystemMessage.RecordFetchSuccesfully;
            response.Data = data;
            response.StatusCodes = (int)ResponseCodes.Success;
            return response;
        }

        public async Task<CustomerTypeResponseDto<object>> GetByIdCustomerTypeAsync(int id)
        {
            var response = new CustomerTypeResponseDto<object>();
            if (id <= 0)
            {
                response.success = false;
                response.Message = SystemMessage.RequiredId;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var res = await _masterRepository.GetByIdCustomerTypeAsync(id);
            if (res == null)
            {
                response.success = false;
                response.Message = SystemMessage.RecordNotFound;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var data = new GetCountry
            {
                Id = res.Id,
                Name = res.Name,
                Description = res.Description,
                IsActive = res.IsActive,
            };
            response.success = true;
            response.Message = SystemMessage.RecordFetchSuccesfully;
            response.Data = data;
            response.StatusCodes = (int)ResponseCodes.Success;
            return response;
        }

        public async Task<IndustryTypeResponse<object>> GetByIdIndustryTypeAsync(int id)
        {
            var response = new IndustryTypeResponse<object>();
            if (id <= 0)
            {
                response.success = false;
                response.Message = SystemMessage.RequiredId;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var res = await _masterRepository.GetByIdIndustryTypeAsync(id);
            if (res == null)
            {
                response.success = false;
                response.Message = SystemMessage.RecordNotFound;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var data = new GetIndustryType
            {
                Id = res.Id,
                Name = res.Name,
                Description = res.Description,
                IsActive = res.IsActive,
            };
            response.success = true;
            response.Message = SystemMessage.RecordFetchSuccesfully;
            response.Data = data;
            response.StatusCodes = (int)ResponseCodes.Success;
            return response;
        }

        public async Task<StateResponseDto<object>> GetByIdStateAsync(int id)
        {
            var response = new StateResponseDto<object>();
            if (id <= 0)
            {
                response.success = false;
                response.Message = SystemMessage.RequiredId;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var res = await _masterRepository.GetByIdStateAsync(id);
            if (res == null)
            {
                response.success = false;
                response.Message = SystemMessage.RecordNotFound;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return response;
            }
            var data = new GetState
            {
                Id = res.Id,
                CountryName = res.Country.Name,
                Name = res.Name,
                Description = res.Description,
                IsActive = res.IsActive,
            };
            response.success = true;
            response.Message = SystemMessage.RecordFetchSuccesfully;
            response.Data = data;
            response.StatusCodes = (int)ResponseCodes.Success;
            return response;
        }

        public async Task<PaginationResponseDto<GetAddress>> GetListAddressAsync(RequestStatusResponse request)
        {
            request.PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            var res = await _masterRepository.GetListAddressAsync(request);
            return new PaginationResponseDto<GetAddress>
            {
                Data = res.Data.Select(x => new GetAddress
                {
                    Id = x.Id,
                    AddressLine1 = x.AddressLine1,
                    AddressLine2 =x.AddressLine2,
                    CityName = x.City.Name,
                    StateName =x.City.State.Name,
                    CountryName =x.City.State.Country.Name,
                    PinCode=x.City.PinCode,
                    Remark =x.Remark,
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

        public async Task<PaginationResponseDto<GetCity>> GetListCityAsync(RequestStatusResponse request)
        {
            request.PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            var res = await _masterRepository.GetListCityAsync(request);
            return new PaginationResponseDto<GetCity>
            {
                Data = res.Data.Select(x => new GetCity
                {
                    Id = x.Id,
                    Name = x.Name,
                    StateName = x.State.Name,
                    PinCode = x.PinCode,
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

        public async Task<PaginationResponseDto<GetCountry>> GetListCountryAsync(RequestStatusResponse request)
        {
            request.PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            var res = await _masterRepository.GetListCountryAsync(request);
            return new PaginationResponseDto<GetCountry>
            {
                Data = res.Data.Select(x => new GetCountry
                {
                    Id = x.Id,
                    Name = x.Name,
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

        public async Task<PaginationResponseDto<GetCustomerType>> GetListCustomerTypeAsync(RequestStatusResponse request)
        {
            request.PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            var res = await _masterRepository.GetListCustomerTypeAsync(request);
            return new PaginationResponseDto<GetCustomerType>
            {
                Data = res.Data.Select(x => new GetCustomerType
                {
                    Id = x.Id,
                    Name = x.Name,
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

        public async Task<PaginationResponseDto<GetIndustryType>> GetListIndustryTypeAsync(RequestStatusResponse request)
        {
            request.PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            var res = await _masterRepository.GetListCityAsync(request);
            return new PaginationResponseDto<GetIndustryType>
            {
                Data = res.Data.Select(x => new GetIndustryType
                {
                    Id = x.Id,
                    Name = x.Name,                
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

        public async Task<PaginationResponseDto<GetState>> GetListStateAsync(RequestStatusResponse request)
        {
            request.PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            var res = await _masterRepository.GetListStateAsync(request);
            return new PaginationResponseDto<GetState>
            {
                Data = res.Data.Select(x => new GetState
                {
                    Id = x.Id,
                    CountryName = x.Country.Name,
                    Name = x.Name,
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

        public async Task<BaseResponse> SaveAddressAsync(CreateAddress dto, string userId)
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

                var data = new Address
                {
                    AddressLine1 = dto.AddressLine1,
                    AddressLine2 = dto.AddressLine2,
                    CityId = dto.CityId,
                    Remark = dto.Remark,
                    IsActive = true,
                    CreateAt = DateTime.Now,
                    CreateBy = userId

                };
                await _masterRepository.SaveAddressAsync(data);
                await _unitOfWork.SaveChangesAsync();
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

        public async Task<BaseResponse> SaveCityAsync(CreateCity dto, string userId)
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

                var data = new Citys
                {
                    Name = dto.Name,
                    StateId = dto.StateId,
                    PinCode = dto.PinCode,
                    Description = dto.Description,
                    IsActive = true,
                    CreateAt = DateTime.Now,
                    CreateBy = userId

                };
                await _masterRepository.SaveCityAsync(data);
                await _unitOfWork.SaveChangesAsync();
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

        public async Task<BaseResponse> SaveCountryAsync(CreateCountry dto, string userId)
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

                var data = new Country
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    IsActive = true,
                    CreateAt = DateTime.Now,
                    CreateBy = userId

                };
                await _masterRepository.SaveCountryAsync(data);
                await _unitOfWork.SaveChangesAsync();
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

        public async Task<BaseResponse> SaveCustomerTypeAsync(CreateCustomerType dto, string userId)
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

                var data = new CustomerType
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    IsActive = true,
                    CreateAt = DateTime.Now,
                    CreateBy = userId

                };
                await _masterRepository.SaveCustomerTypeAsync(data);
                await _unitOfWork.SaveChangesAsync();
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

        public async Task<BaseResponse> SaveIndustryTypeAsync(CreateIndustryType dto, string userId)
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

                var data = new IndustryType
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    IsActive = true,
                    CreateAt = DateTime.Now,
                    CreateBy = userId

                };
                await _masterRepository.SaveIndustryTypeAsync(data);
                await _unitOfWork.SaveChangesAsync();
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

        public async Task<BaseResponse> SaveStateAsync(CreateState dto, string userId)
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

                var data = new State
                {
                    Name = dto.Name,
                    CountryId = dto.CountryId,
                    Description = dto.Description,
                    IsActive = true,
                    CreateAt = DateTime.Now,
                    CreateBy = userId

                };
                await _masterRepository.SaveStateAsync(data);
                await _unitOfWork.SaveChangesAsync();
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

        public async Task<BaseResponse> UpdateAddressAsync(UpdateAddress dto, string userId)
        {

            var respone = new BaseResponse();
            if (dto.Id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _masterRepository.UpdateAddressAsync(dto.Id);
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
            data.AddressLine1 = dto.AddressLine1;
            data.AddressLine2 = dto.AddressLine2;
            data.Remark = dto.Remark;
            data.CityId = dto.CityId;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }

        public async Task<BaseResponse> UpdateAddressStatusAsync(int id, string userId)
        {
            var respone = new BaseResponse();
            if (id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _masterRepository.UpdateAddressAsync(id);
            if (data == null)
            {
                respone.Message = SystemMessage.RecordNotFound;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            data.IsActive = !data.IsActive;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }

        public async Task<BaseResponse> UpdateCityAsync(UpdateCity dto, string userId)
        {
            var respone = new BaseResponse();
            if (dto.Id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _masterRepository.UpdateCityAsync(dto.Id);
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
            data.Name = dto.Name;
            data.StateId = dto.StateId;
            data.PinCode = dto.PinCode;
            data.Description = dto.Description;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }

        public async Task<BaseResponse> UpdateCityStatusAsync(int id, string userId)
        {
            var respone = new BaseResponse();
            if (id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _masterRepository.UpdateCityAsync(id);
            if (data == null)
            {
                respone.Message = SystemMessage.RecordNotFound;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            data.IsActive = !data.IsActive;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;

        }

        public async Task<BaseResponse> UpdateCountryAsync(UpdateCountry dto, string userId)
        {
            var respone = new BaseResponse();
            if (dto.Id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _masterRepository.UpdateCountryAsync(dto.Id);
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
            data.Name = dto.Name;
            data.Description = dto.Description;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }

        public async Task<BaseResponse> UpdateCountryStatusAsync(int id, string userId)
        {
            var respone = new BaseResponse();
            if (id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _masterRepository.UpdateCountryAsync(id);
            if (data == null)
            {
                respone.Message = SystemMessage.RecordNotFound;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            data.IsActive = !data.IsActive;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }

        public async Task<BaseResponse> UpdateCustomerTypeAsync(UpdateCustomerType dto, string userId)
        {
            var respone = new BaseResponse();
            if (dto.Id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _masterRepository.UpdateCustomerTypeAsync(dto.Id);
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
            data.Name = dto.Name;
            data.Description = dto.Description;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }

        public async Task<BaseResponse> UpdateCustomerTypeStatusAsync(int id, string userId)
        {
            var respone = new BaseResponse();
            if (id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _masterRepository.UpdateCustomerTypeAsync(id);
            if (data == null)
            {
                respone.Message = SystemMessage.RecordNotFound;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            data.IsActive = !data.IsActive;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }

        public async Task<BaseResponse> UpdateIndustryTypeAsync(UpdateIndustryType dto, string userId)
        {
            var respone = new BaseResponse();
            if (dto.Id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _masterRepository.UpdateIndustryTypeAsync(dto.Id);
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
            data.Name = dto.Name;
            data.Description = dto.Description;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }

        public async Task<BaseResponse> UpdateIndustryTypeStatusAsync(int id, string userId)
        {
            var respone = new BaseResponse();
            if (id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _masterRepository.UpdateIndustryTypeAsync(id);
            if (data == null)
            {
                respone.Message = SystemMessage.RecordNotFound;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            data.IsActive = !data.IsActive;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }

        public async Task<BaseResponse> UpdateStateAsync(UpdateState dto, string userId)
        {
            var respone = new BaseResponse();
            if (dto.Id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _masterRepository.UpdateStateAsync(dto.Id);
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
            data.Name = dto.Name;
            data.CountryId = dto.CountryId;
            data.Description = dto.Description;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }

        public async Task<BaseResponse> UpdateStateStatusAsync(int id, string userId)
        {
            var respone = new BaseResponse();
            if (id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _masterRepository.UpdateStateAsync(id);
            if (data == null)
            {
                respone.Message = SystemMessage.RecordNotFound;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            data.IsActive = !data.IsActive;
            data.ModifyBy = userId;
            data.ModifyAt = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();

            respone.Message = SystemMessage.RecordUpdateSuccesfully;
            respone.StatusCodes = (int)ResponseCodes.Success;
            return respone;
        }
    }
}
