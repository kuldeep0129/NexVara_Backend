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
    public class EmployeeBankDetails : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public ApplicationUser Employee { get; set; }
        public string? BankName { get; set; }
        public string? AccountNo { get; set; }
        public string? IFSCCode {  get; set; }
        public string? Branch { get;set; }
    }
}
