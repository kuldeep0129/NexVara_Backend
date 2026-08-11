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
    public interface IDepartmentServices
    {
        Task<BaseResponse> SaveAsync(AddDepartmentDto dto, String UserId);
        Task<BaseResponse> UpdateAsync(UpdateDepartmentDto dto, String UserId);
        Task<BaseResponse> UpdateStatusAsync(int id, string userId);
        Task<DepatmentDto<object>> GetByIdDepartmentAsync(int id);
        Task<PaginationResponseDto<GetDepartment>> GetListDepartmentAsync(RequestStatusResponse request);
    }
}
