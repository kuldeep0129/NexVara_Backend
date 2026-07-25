using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Core.Common
{
    public class BaseDbModel
    {
        public bool IsActive { get; set; } = true;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } 
        public DateTime? ModifyAt { get; set; } = DateTime.Now;
        public string? ModifyBy { get; set; } 
    }
}
