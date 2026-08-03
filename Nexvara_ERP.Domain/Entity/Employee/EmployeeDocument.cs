using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Identiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Employee
{
    public class EmployeeDocument : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public ApplicationUser Employee {  get; set; }
        public int? DocumentTypeId { get; set; }
        public DocumentType DocumentType {  get; set; }
        public string? FilePath { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
