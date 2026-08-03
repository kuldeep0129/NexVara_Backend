using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.Interface.IServices
{
    public interface ICompaninesServices
    {
        Task<BaseResponse> SaveAsync(addcompaniesdto dto, string userId);
        Task<BaseResponse> UpdateAsync(Updatecompaniesdto dto, string userId);
        Task<BaseResponse> UpdateStatusAsync(int id, string userId);
        Task<CompanyResponseDto<object>> GetByIdCompanyAsync(int id);
        Task<PaginationResponseDto<Getcompinesdto>> GetListCompanyAsync(RequestStatusResponse request);
    }
}
