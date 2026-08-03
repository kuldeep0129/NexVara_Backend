using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Entity.Master;
using Nexvara_ERP.Domain.Identiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Employee
{
    public class Employee : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string? EmpCode { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public int? GenderId { get; set; }
        public Gender Gender { get; set; }
        public string? OfficalEmail { get; set; }
        public string? PersnalMobileNo { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? DesignationId { get; set; }
        public Designation Designation { get; set; }
        public int? ReportingManagerId { get; set; }
        public ApplicationUser ReportingManager { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? RelievingDate { get; set; }
        public int? EmploymentTypeId { get; set; }
        public EmployeeType EmploymentType { get; set; }
        public int? EmploymentStatusId { get; set; }
        public EmployeeStatus EmploymentStatus { get; set; }

        public string? ProfileImage { get; set; }
        public string? Remarks { get; set; }


    }
}
