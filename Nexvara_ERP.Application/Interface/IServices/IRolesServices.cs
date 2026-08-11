using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
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
    public interface IRolesServices
    {
        #region Department
        Task<BaseResponse> SaveDepartmentAsync(CreateDepartment dto, string userId);
        Task<BaseResponse> UpdateDepartmentAsync(UpdateDepartment dto, string userId);
        Task<BaseResponse> UpdateDepartmentStatusAsync(int id, string userId);
        Task<ResponseDepartment<object>> GetByIdDepartmentAsync(int id);
        Task<PaginationResponseDto<GetDepartment>> GetListDepartmentAsync(RequestStatusResponse request);
        #endregion

        #region Designation
        Task<BaseResponse> SaveDesignationAsync(CreateDesignation dto, string userId);
        Task<BaseResponse> UpdateDesignationAsync(UpdateDesignation dto, string userId);
        Task<BaseResponse> UpdateDesignationStatusAsync(int id, string userId);
        Task<ResponseDesignation<object>> GetByIdDesignationAsync(int id);
        Task<PaginationResponseDto<GetDesignation>> GetListDesignationAsync(RequestStatusResponse request);

        #endregion
    }
}
