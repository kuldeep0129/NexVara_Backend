using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.UpdateDto
{
    public class UpdateDesignation
    {
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public string DesignationName { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
    }
}
