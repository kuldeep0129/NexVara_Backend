using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Sales
{
    public class QuotationItem : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public int? QuotationId { get; set; }
        public Quotation Quotation { get; set; }
        public int? ProductServiceId { get; set; }
        public ProductCategory ProductService{ get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public int? TaxId { get; set; }
        public Tax? Tax { get; set; }
        public decimal? TaxAmount { get; set; }

    }
}
