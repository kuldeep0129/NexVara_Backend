using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Sales
{
    public class SalesOrder : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public string? Order_Number { get; set; }
        public string? Customer { get; set; }
        public string? Status { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
    }
}
