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
    public class CreateState
    {
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
    public class StateResponseDto<T> : BaseResponse
    {
        public bool success { get; set; }
        public T? Data { get; set; }
    }
}
