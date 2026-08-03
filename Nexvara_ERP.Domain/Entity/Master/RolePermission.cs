using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Identiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Domain.Entity.Master
{
    public class RolePermission : BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int? PermissionsId { get; set; }
        public Permissions? Permissions { get; set; }
    }
}
