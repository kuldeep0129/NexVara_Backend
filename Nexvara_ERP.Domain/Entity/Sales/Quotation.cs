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
    public class Quotation : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public string QuotationNumber { get; set; }
        public int? OpportunityId { get; set; }
        public Opportunity Opportunity { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? SalesPersonId { get; set; }
        public ApplicationUser SalesPerson{ get; set; }
        public int? PaymentTermId { get; set; }
        public PaymentTerm PaymentTerm{ get; set; }
        public int? CurrencyId { get; set; }
        public Currency Currency{ get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? QuotationStatusId { get; set; }
        public QuotationStatus QuotationStatus { get; set; }
        public string? Note { get; set; }
        public DateTime? QuotationDate { get; set; }
        public DateTime? ValidTillDate { get; set; }

    }
}
