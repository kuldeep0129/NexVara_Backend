using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.Interface.IRepository
{
    public interface IRolesRepository
    {
        #region Department
        Task SaveDepartmentAsync(Department source);
        Task<Department?> GetByIdDepartmentAsync(int id);
        Task<PaginationResponseDto<Department>> GetListDepartmentAsync(RequestStatusResponse response);
        Task<Department?> UpdateDepartmentAsync(int id);
        Task<string> GetLastIdDepartmentAsync();
        #endregion

        #region Designation
        Task SaveDesignationAsync(Designation source);
        Task<Designation?> GetByIdDesignationAsync(int id);
        Task<PaginationResponseDto<Designation>> GetListDesignationAsync(RequestStatusResponse response);
        Task<Designation?> UpdateDesignationAsync(int id);
        Task<string> GetLastIdDesignationAsync();
        #endregion


    }
}
