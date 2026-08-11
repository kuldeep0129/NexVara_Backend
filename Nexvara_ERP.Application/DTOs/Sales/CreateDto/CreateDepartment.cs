using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Identiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.CreateDto
{
    public class CreateDepartment
    {
        public string DepartmentName { get; set; }
        public string? Description { get; set; }
        public int RoleId { get; set; }
    }
    public class ResponseDepartment<T> : BaseResponse
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
    }
}
