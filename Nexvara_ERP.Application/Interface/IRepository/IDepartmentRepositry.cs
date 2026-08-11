using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.Interface.IRepository
{
    public interface IDepartmentRepositry
    {
        Task SaveAsync(Department department);
        Task<Department?> GetByDepartmentAsync(int  departmentId);
        Task<PaginationResponseDto<Department>> GetListDepartmentAsync(RequestStatusResponse response);
        Task<Department?> UpdateAsync(int departmentId);
    }
}
