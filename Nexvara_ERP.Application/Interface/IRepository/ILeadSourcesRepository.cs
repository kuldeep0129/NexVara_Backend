using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.Interface.IRepository
{
    public interface ILeadSourcesRepository
    {
        #region LeadSources
        Task SaveAsync(LeadSources source);
        Task<LeadSources?> GetByIdLeadSourcesAsync(int id);
        Task<PaginationResponseDto<LeadSources>> GetListLeadSourcesAsync(RequestStatusResponse response);
        Task<LeadSources?> UpdateAsync(int id);
        #endregion

        #region LeadStatus
        Task SaveLeadStatusAsync(LeadStatus source);
        Task<LeadStatus?> GetByIdLeadStatusAsync(int id);
        Task<PaginationResponseDto<LeadStatus>> GetListLeadStatusAsync(RequestStatusResponse response);
        Task<LeadStatus?> UpdateLeadStatusAsync(int id);
        #endregion
    }
}
