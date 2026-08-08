using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales.GetDto
{
    public class GetState
    {
        public int Id { get; set; }

        public string  CountryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool  IsActive { get; set; }
    }
}
