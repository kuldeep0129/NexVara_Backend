using Nexvara_ERP.Domain.Identiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.GetDto
{
    public class GetDepartment
    {
        public int Id { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string? Description { get; set; }
        public string RoleName { get; set; }

        public string Status { get; set; }
        public bool IsActive { get; set; }
    }
}
