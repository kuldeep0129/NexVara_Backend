using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Master
{
    public class Address : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public int? CityId { get; set; }
        public Citys City { get; set; }

        [Required]
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Remark { get; set; }
    }
}
