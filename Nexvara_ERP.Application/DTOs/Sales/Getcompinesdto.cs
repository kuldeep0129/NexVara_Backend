using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales
{
    public class Getcompinesdto
    {
        public int Id { get; set; }
        

        public string CompanyName { get; set; }
        
        public int IndustryId { get; set; }
        
        public int CompanySizeId { get; set; }
        
        public string Website { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public int CountryId { get; set; }
        
        public int StateId { get; set; }
        
        public int CityId { get; set; }
        
        public string Address { get; set; }
        
        public int PinCode { get; set; }
        
        public string GSTNumber { get; set; }
        
        public string PANNumber { get; set; }
    }
    public class CompanyResponseDto<T> : BaseResponse
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
    }
}
