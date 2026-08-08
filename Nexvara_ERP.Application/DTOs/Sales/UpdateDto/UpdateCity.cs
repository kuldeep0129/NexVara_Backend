using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.UpdateDto
{
    public class UpdateCity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? PinCode { get; set; }
    }
}
