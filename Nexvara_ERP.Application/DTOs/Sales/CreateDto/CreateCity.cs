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
    public class CreateCity
    {

        [Required]
        public int StateId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? PinCode { get; set; }
    }
    public class CityResponseDto<T> : BaseResponse
    {
        public bool success { get; set; }
        public T? Data { get; set; }
    }
}
