using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.CreateDto
{
    public class CreateCustomerType
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
    public class CustomerTypeResponseDto<T> : BaseResponse
    {
        public bool success { get; set; }
        public T? Data { get; set; }
    }
}
