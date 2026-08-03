using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Identiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Master
{
    public class Department : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string? Description { get; set; }
        public int? RoleId { get; set; }
        public ApplicationRole Role { get; set; }

        public string Status { get; set; }
    }
}
