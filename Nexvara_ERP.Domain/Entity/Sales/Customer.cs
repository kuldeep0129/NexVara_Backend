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
    public class Customer : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }

        public string? CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? GSTNumber { get; set; }
        public string? PANNumber { get; set; }
        public int? PaymentTermId { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
        public int? IndustryTypeId { get; set; }
        public IndustryType IndustryType{ get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public string? Status { get; set; }
    }
}
