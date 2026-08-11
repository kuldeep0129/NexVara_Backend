using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Master
{
    public class Permissions : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
       public string PermissionCode { get; set; }
        public string Module {  get; set; }
        public bool IsAction { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
    }
}
