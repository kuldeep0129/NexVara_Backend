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
    public class SalesOrderItem : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public string? Product {  get; set; }
        public int? Quantity {  get; set; }
        public decimal? Rate {  get; set; }
        public int? TaxId {  get; set; }
        public Tax Tax { get; set; }
    }
}
