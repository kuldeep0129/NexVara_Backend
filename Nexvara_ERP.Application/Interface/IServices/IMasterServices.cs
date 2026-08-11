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
    public interface IMasterServices
    {
        #region Country
        Task<BaseResponse> SaveCountryAsync(CreateCountry dto, string userId);
        Task<BaseResponse> UpdateCountryAsync(UpdateCountry dto, string userId);
        Task<BaseResponse> UpdateCountryStatusAsync(int id, string userId);
        Task<CountryResponseDto<object>> GetByIdCountryAsync(int id);
        Task<PaginationResponseDto<GetCountry>> GetListCountryAsync(RequestStatusResponse request);
        #endregion

        #region State
        Task<BaseResponse> SaveStateAsync(CreateState dto, string userId);
        Task<BaseResponse> UpdateStateAsync(UpdateState dto, string userId);
        Task<BaseResponse> UpdateStateStatusAsync(int id, string userId);
        Task<StateResponseDto<object>> GetByIdStateAsync(int id);
        Task<PaginationResponseDto<GetState>> GetListStateAsync(RequestStatusResponse request);
        #endregion


        #region City
        Task<BaseResponse> SaveCityAsync(CreateCity dto, string userId);
        Task<BaseResponse> UpdateCityAsync(UpdateCity dto, string userId);
        Task<BaseResponse> UpdateCityStatusAsync(int id, string userId);
        Task<CityResponseDto<object>> GetByIdCityAsync(int id);
        Task<PaginationResponseDto<GetCity>> GetListCityAsync(RequestStatusResponse request);
        #endregion


        #region Address
        Task<BaseResponse> SaveAddressAsync(CreateAddress dto, string userId);
        Task<BaseResponse> UpdateAddressAsync(UpdateAddress dto, string userId);
        Task<BaseResponse> UpdateAddressStatusAsync(int id, string userId);
        Task<AddressResponseDto<object>> GetByIdAddressAsync(int id);
        Task<PaginationResponseDto<GetAddress>> GetListAddressAsync(RequestStatusResponse request);
        #endregion

        #region CustomerType
        Task<BaseResponse> SaveCustomerTypeAsync(CreateCustomerType dto, string userId);
        Task<BaseResponse> UpdateCustomerTypeAsync(UpdateCustomerType dto, string userId);
        Task<BaseResponse> UpdateCustomerTypeStatusAsync(int id, string userId);
        Task<CustomerTypeResponseDto<object>> GetByIdCustomerTypeAsync(int id);
        Task<PaginationResponseDto<GetCustomerType>> GetListCustomerTypeAsync(RequestStatusResponse request);
        #endregion

        #region IndustryType
        Task<BaseResponse> SaveIndustryTypeAsync(CreateIndustryType dto, string userId);
        Task<BaseResponse> UpdateIndustryTypeAsync(UpdateIndustryType dto, string userId);
        Task<BaseResponse> UpdateIndustryTypeStatusAsync(int id, string userId);
        Task<IndustryTypeResponse<object>> GetByIdIndustryTypeAsync(int id);
        Task<PaginationResponseDto<GetIndustryType>> GetListIndustryTypeAsync(RequestStatusResponse request);
        #endregion

    }
}
