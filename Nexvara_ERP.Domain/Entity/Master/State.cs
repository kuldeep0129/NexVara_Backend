using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Master
{
    public class State : BaseDbModel
    {
        [Key]
        public int Id { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
