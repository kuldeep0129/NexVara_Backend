using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity
{
    public class Company : BaseDbModel
    {

        [Key]
        public int Id { get; set; }

        [Required]

        public string CompanyName { get; set; }
        [Required]
        public int IndustryId { get; set; }
        [Required]
        public int CompanySizeId { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int PinCode { get; set; }
        [Required]
        public string GSTNumber { get; set; }
        [Required]
        public string PANNumber { get; set; }
    }
}
