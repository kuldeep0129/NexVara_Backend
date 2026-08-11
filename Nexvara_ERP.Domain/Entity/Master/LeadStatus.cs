using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Master
{
    public class LeadStatus : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? desciption { get; set; }
        public bool IsFinalStatus { get; set; }
    }
}
