using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.Interface.IServices
{
    public interface ILeadSourcesServices 
    {
        Task<BaseResponse> SaveAsync(AddLeadSourcesDto dto,string userId);
        Task<BaseResponse> UpdateAsync(UpdateLeadSourcesDto dto, string userId);
        Task<BaseResponse> UpdateStatusAsync(int id, string userId);
        Task<LeadSourcesResponseDto<object>> GetByIdLeadSourcesAsync(int id);
        Task<PaginationResponseDto<GetLeadSourcesDto>> GetListLeadSourcesAsync(RequestStatusResponse request );
    }
}
