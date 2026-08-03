using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Entity.Master;
using Nexvara_ERP.Domain.Identiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Sales
{
    public class Lead : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public string LeadNumber { get; set; }
        public string? LeadTitle { get; set; }
        public string? RequirementDescription { get; set; }
        
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? LeadSourceId { get; set; }
        public LeadSources LeadSource { get; set; }
        public int? LeadStatusId { get; set; }
        public LeadStatus LeadStatus { get; set; }
        public int? AssignedToEmployeeId { get; set; }
        public ApplicationUser AssignedToEmployee { get; set; }
        public decimal? ExpectedValue { get; set; }
        public DateTime? ExpectedCloseDate { get; set; }
        public string? Priority { get; set; }
    }
}
