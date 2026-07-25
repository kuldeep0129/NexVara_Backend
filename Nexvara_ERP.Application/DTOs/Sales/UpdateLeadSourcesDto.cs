using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales
{
    public class UpdateLeadSourcesDto
    {
        [Required(ErrorMessage = "Lead Id is Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lead Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lead Description is Required")]
        public string Description { get; set; }
    }
}
