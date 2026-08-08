using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.UpdateDto
{
    public class UpdateCountry
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
