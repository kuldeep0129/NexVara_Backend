using Nexvara_ERP.Application.DTOs.Common;
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
    public class PaymentMethodServices : IPaymentMethodServices
    {
        private readonly IPaymentMethod _service;
        private readonly IUnitofWork _unitOfWork;

        public PaymentMethodServices(IPaymentMethod service, IUnitofWork unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }
        public async Task<PaymentTypeResponse<object>> GetByIdPaymentMethodAsync(int id)
        {
            var response = new PaymentTypeResponse<object>();

            if (id <= 0)
            {
                response.success = false;
                response.Message = SystemMessage.RequiredId;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;

                return response;
            }

            var res = await _service.GetByIdPaymentMethodAsync(id);

            if (res == null)
            {
                response.success = false;
                response.Message = SystemMessage.RecordNotFound;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;

                return response;
            }

            var data = new GetPaymentMethod
            {
                Name = res.Name,
                Description = res.Description
            };

            response.success = true;
            response.Message = SystemMessage.RecordFetchSuccesfully;
            response.Data = data;
            response.StatusCodes = (int)ResponseCodes.Success;

            return response;
        }
        public async Task<PaginationResponseDto<GetPaymentMethod>> GetListPaymentMethodAsync(RequestStatusResponse request)
        {
            request.PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize <= 0 ? 10 : request.PageSize;
            var res = await _service.GetListPaymentMethodAsync(request);
            return new PaginationResponseDto<GetPaymentMethod>
            {
                Data = res.Data.Select(x => new GetPaymentMethod
                {
                    Name = x.Name,
                    Description = x.Description,
                   
                }).ToList(),
                PageNumber = res.PageNumber,
                PageSize = res.PageSize,
                TotalPages = res.TotalPages,
                TotalRecords = res.TotalRecords,
                Message = SystemMessage.RecordFetchSuccesfully,
                StatusCodes = (int)ResponseCodes.Success
            };
        }
        public async Task<BaseResponse> SavePaymentMethodAsync(CreatePaymentMethod dto, string userId)
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

                var data = new PaymentMethod
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    
                    CreateAt = DateTime.Now,
                    CreateBy = userId

                };
                await _service.SavePaymentMethodAsync(data);
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
        public async Task<BaseResponse> UpdatePaymentMethodAsync(UpdatePaymentMethod dto, string userId)
        {
            var respone = new BaseResponse();
            if (dto.Id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _service.UpdatePaymentMethodAsync(dto.Id);
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
        public async Task<BaseResponse> UpdatePaymentMethodStatusAsync(int id, string userId)
        {
            var respone = new BaseResponse();
            if (id <= 0)
            {
                respone.Message = SystemMessage.RequiredId;
                respone.StatusCodes = (int)ResponseCodes.BadRequest;
                return respone;
            }
            var data = await _service.UpdatePaymentMethodAsync(id);
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
