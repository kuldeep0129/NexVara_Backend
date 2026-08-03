using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Sales
{
    public class OpportunityStaged : BaseDbModel
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal? ProbabilityPercentage { get; set; }
        public string? desciption { get; set; }
        public bool IsWonStage { get; set; }
        public bool IsLostStage { get; set; }
    }
}
