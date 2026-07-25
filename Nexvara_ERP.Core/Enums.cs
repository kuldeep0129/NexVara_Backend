using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Core
{
    public enum Enums
    {
        
    }
    public enum Roles
    {
        [Description("SuperAdmin")]
        SuperAdmin =0,
        [Description("Admin")]
        Admin =1,
        [Description("Sales")]
        Sales =2,
    }
}
