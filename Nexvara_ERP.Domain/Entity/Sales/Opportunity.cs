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
    public class Opportunity : BaseDbModel
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string OpportunityNumber { get; set; }
        public string? OpportunityName { get; set; }
        public int? LeadId { get; set; }
        public Lead Lead{ get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer{ get; set; }
        public int? OpportunityStageId { get; set; }
        public OpportunityStaged OpportunityStage{ get; set; }
        public int? SalesPersonId { get; set; }
        public ApplicationUser SalesPerson{ get; set; }
        public string? desciption { get; set; }
        public decimal? ExpectedAmount { get; set; }
        public decimal? ProbabilityPercentage { get; set; }
        public DateTime? ExpectedCloseDate { get; set; }
        public string? priority { get; set; }
    }
}
