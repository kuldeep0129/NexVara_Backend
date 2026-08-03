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
    public class Branch : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public string BrachCode { get; set; }
        [Required]
        public string BranchName { get; set; }
        [Required]
        public string Email     { get; set; }
        [Required]
        public string Mobile { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public int? ManagerEmployeeId { get; set; }
        public ApplicationUser ManagerEmployee { get; set; }

        public bool IsHeadOffice { get; set; }
        public string Status { get; set; }

    }
}
