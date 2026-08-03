using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
using Nexvara_ERP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.Interface.IRepository
{
    public interface ICompaniesRepositry
    {
        Task SaveAsync(Company company);
        Task<Company?> GetByCompanyIdAsync(int id);
        Task<PaginationResponseDto<Company>> GetListCompaniesAsync(RequestStatusResponse response);
        Task<Company?> UpdateAsync(int id);
    }
}
