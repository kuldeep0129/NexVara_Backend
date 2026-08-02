using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales
{
    public class GetDepartment
    {
        public int DepartmentId { get; set; }
        
        public string DepartmentCode { get; set; }
        
        public string DepartmentName { get; set; }

        public string Description { get; set; }
        
        public int? RoleId { get; set; }
       
        public bool IsHeadOffice { get; set; }
        
        public string Status { get; set; }
    }
    public class DepatmentDto<T> : BaseResponse
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
    }
}
