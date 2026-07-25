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
    public interface ILeadSourcesRepository
    {
        Task SaveAsync(LeadSources source);
        Task<LeadSources?> GetByIdLeadSourcesAsync(int id);
        Task<PaginationResponseDto<LeadSources>> GetListLeadSourcesAsync(RequestStatusResponse response);
        Task<LeadSources?> UpdateAsync(int id);
    }
}
