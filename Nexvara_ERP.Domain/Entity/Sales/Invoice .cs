using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Sales
{
    public class Invoice : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public string? Invoice_Number { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? TotalAmount  { get; set; }
    }
}
