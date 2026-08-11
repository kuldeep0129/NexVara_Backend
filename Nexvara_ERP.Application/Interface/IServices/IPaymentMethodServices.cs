using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales.CreateDto;
using Nexvara_ERP.Application.DTOs.Sales.GetDto;
using Nexvara_ERP.Application.DTOs.Sales.UpdateDto;
using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.Interface.IServices
{
    public interface IPaymentMethodServices
    {
        Task<BaseResponse> SavePaymentMethodAsync(CreatePaymentMethod dto, string userId);
        Task<BaseResponse> UpdatePaymentMethodAsync(UpdatePaymentMethod dto, string userId);
        Task<BaseResponse> UpdatePaymentMethodStatusAsync(int id, string userId);
        Task<PaymentTypeResponse<object>> GetByIdPaymentMethodAsync(int id);
        Task<PaginationResponseDto<GetPaymentMethod>> GetListPaymentMethodAsync(RequestStatusResponse request);
    }
}
