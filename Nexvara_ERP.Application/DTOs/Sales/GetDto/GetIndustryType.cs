using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.GetDto
{
    public class GetIndustryType
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }  
    }
}
