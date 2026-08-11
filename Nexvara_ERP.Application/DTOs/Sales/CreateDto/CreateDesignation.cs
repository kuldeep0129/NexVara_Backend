using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.CreateDto
{
    public class CreateDesignation
    {
        public int DepartmentId { get; set; }
        public string DesignationName { get; set; }
        public string? Description { get; set; }
        
    }
    public class ResponseDesignation <T> : BaseResponse
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
    }
}
