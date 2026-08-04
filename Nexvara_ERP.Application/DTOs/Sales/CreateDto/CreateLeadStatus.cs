using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.CreateDto
{
    public class CreateLeadStatus
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class LeadStatusResponseDto<T> : BaseResponse
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
    }
}
