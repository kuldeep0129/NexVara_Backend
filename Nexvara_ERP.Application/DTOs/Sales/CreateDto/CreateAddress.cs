using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.CreateDto
{
    public class CreateAddress
    {
        [Required]
        public int CityId { get; set; }

        [Required]
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Remark { get; set; }
    }
    public class AddressResponseDto<T> : BaseResponse
    {
        public bool success { get; set; }
        public T? Data { get; set; }
    }
}
