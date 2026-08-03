using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Identiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Sales
{
    public class LeadActivity : BaseDbModel
    {
        [Key]
        public int Id { get; set; }


        public int? LeadId { get; set; }
        [ForeignKey(nameof(LeadId))]
        public  Lead? Lead{ get; set; }

        public int? ActivityTypeId { get; set; }
        //[ForeignKey(nameof(ActivityTypeId))]
        //public ActivityType? ActivityType { get; set; }

        public int? AssignedToEmployeeId { get; set; }
        [ForeignKey(nameof(AssignedToEmployeeId))]
        public  ApplicationUser? AssignedToEmployee{ get; set; }

        public DateTime? ActivityDate { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public string? ActivityStatus { get; set; }
        public string? AttachmentPath { get; set; }
    }
}
