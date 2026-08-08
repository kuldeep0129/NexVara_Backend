using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.Interface.IRepository
{
    public interface IMasterRepository
    {
        #region Country
        Task SaveCountryAsync(Country country);
        Task<Country?> GetByIdCountryAsync(int id);
        Task<Country?> UpdateCountryAsync(int id);
        Task<PaginationResponseDto<Country>> GetListCountryAsync(RequestStatusResponse response);
        #endregion

        #region State
        Task SaveStateAsync(State state);
        Task<State?> GetByIdStateAsync(int id);
        Task<State?> UpdateStateAsync(int id);
        Task<PaginationResponseDto<State>> GetListStateAsync(RequestStatusResponse response);
        #endregion

        #region City
        Task SaveCityAsync(Citys city);
        Task<Citys?> GetByIdCityAsync(int id);
        Task<Citys?> UpdateCityAsync(int id);
        Task<PaginationResponseDto<Citys>> GetListCityAsync(RequestStatusResponse response);
        #endregion

        #region Address
        Task SaveAddressAsync(Address address);
        Task<Address?> GetByIdAddressAsync(int id);
        Task<Address?> UpdateAddressAsync(int id);
        Task<PaginationResponseDto<Address>> GetListAddressAsync(RequestStatusResponse response);
        #endregion

        #region CustomerType
        Task SaveCustomerTypeAsync(CustomerType type);
        Task<CustomerType?> GetByIdCustomerTypeAsync(int id);
        Task<CustomerType?> UpdateCustomerTypeAsync(int id);
        Task<PaginationResponseDto<CustomerType>> GetListCustomerTypeAsync(RequestStatusResponse response);
        #endregion


        #region IndustryType
        Task SaveIndustryTypeAsync(IndustryType type);
        Task<IndustryType?> GetByIdIndustryTypeAsync(int id);
        Task<IndustryType?> UpdateIndustryTypeAsync(int id);
        Task<PaginationResponseDto<IndustryType>> GetListIndustryTypeAsync(RequestStatusResponse response);
        #endregion

    }
}
