using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.Interface.IRepository
{
    public interface IPaymentMethod
    {
        Task SavePaymentMethodAsync(PaymentMethod paymentMethod);
        Task<PaymentMethod?> GetByIdPaymentMethodAsync(int id);
        Task<PaymentMethod?> UpdatePaymentMethodAsync(int id);
        Task<PaginationResponseDto<PaymentMethod>> GetListPaymentMethodAsync(RequestStatusResponse response);
    }
}
