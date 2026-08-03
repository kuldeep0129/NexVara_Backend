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
    public class Services : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Type { get; set; }
        public int? CategoryId { get; set; }
        public ProductCategory Category { get; set; }
        public string? desciption { get; set; }
        public decimal? BestPrice { get; set; }
    }
}
