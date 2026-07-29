using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Sales
{
    public class addcompaniesdto
    {
        [Required(ErrorMessage = "Company Name is Required")]

        public string CompanyName { get; set; }
        [Required(ErrorMessage = "IndustryId is Required")]
        public int IndustryId { get; set; }
        [Required(ErrorMessage = "CompanySizeId is Required")]
        public int CompanySizeId { get; set; }
        [Required(ErrorMessage = "Website Name is Required")]
        public string Website { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "CountryId is Required")]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "StateId is Required")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "CityId is Required")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "PinCode is Required")]
        public int PinCode { get; set; }
        [Required(ErrorMessage = "GST Number is Required")]
        public string GSTNumber { get; set; }
        [Required(ErrorMessage = "Pan Number is Required")]
        public string PANNumber { get; set; }
    }
}
