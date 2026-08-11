using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Identiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Employee
{
    public class EmployeeEmegencyContact : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public ApplicationUser Employee { get; set; }
        public string? ContactName{ get; set; }
        public string?  Relation {  get; set; }

        public string? MobileNo { get; set; }
    }
}
