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
    public class PaymentReceipt : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public string? ReceiptNumber { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? InvoiceId {  get; set; }
        public Invoice Invoice { get; set; }
        public int? PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? TransactionReference { get; set; }
        public decimal? AmountReceived { get; set; }
        public string? BankName { get; set; }
        public string? AccountNumber { get; set; }
        public string? UTRNumber { get; set; }
        public string? Remarks { get; set; }
        public string? Status { get; set; }
    }
}
