using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.GetDto
{
    public class GetPaymentMethod
    {
        
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
