using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.GetDto
{
    public class GetAddress
    {
        public int Id { get; set; }
        public string PinCode { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Remark { get; set; }
        public bool IsActice { get; set; }
    }
}
