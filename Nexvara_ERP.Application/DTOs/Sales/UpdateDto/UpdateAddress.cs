using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.UpdateDto
{
    public class UpdateAddress
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CityId { get; set; }

        [Required]
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Remark { get; set; }
    }
}
