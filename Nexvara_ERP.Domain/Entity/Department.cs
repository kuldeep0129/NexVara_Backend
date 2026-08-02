using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity
{
    public class Department :BaseDbModel
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentCode { get; set; }
        [Required]
        public string DepartmentName { get; set; }
       
        public string Description { get; set; }
        [Required]
        public int? RoleId { get; set; }      
        [Required]
        public bool IsHeadOffice { get; set; }
        [Required]
        public string Status { get; set; }
        

    }
}
