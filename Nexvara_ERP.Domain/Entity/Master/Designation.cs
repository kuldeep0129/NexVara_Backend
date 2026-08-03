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
    public class Designation : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public string DesignationCode { get; set; }
        public string DesignationName { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
    }
}
