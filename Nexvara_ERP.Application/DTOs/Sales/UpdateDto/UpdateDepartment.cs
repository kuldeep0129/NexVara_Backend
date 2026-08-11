using Nexvara_ERP.Domain.Identiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.UpdateDto
{
    public class UpdateDepartment
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string? Description { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; }
    }
}
