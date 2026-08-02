using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales
{
    public class UpdateDepartmentDto
    {
        [Required(ErrorMessage = "Lead DepartmentId is Required")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "DepartmentCode is Required")]
        public string DepartmentCode { get; set; }
        [Required(ErrorMessage = "DepartmentName is Required")]
        public string DepartmentName { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "RoleId is Required")]
        public int? RoleId { get; set; }
        [Required(ErrorMessage = "Headoffice is Required")]
        public bool IsHeadOffice { get; set; }
        [Required(ErrorMessage = "Status is Required")]
        public string Status { get; set; }
    }
}
