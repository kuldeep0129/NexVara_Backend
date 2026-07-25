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

    public enum EntityStatusType
    {
        [Description("All")]
        All = 0,

        [Description("Active")]
        Active = 1,

        [Description("InActive")]
        InActive = 2,

    }
    public enum ResponseCodes
    {
        [Description("Error")]
        Error = 0,
        [Description("Success")]
        Success = 200,
        [Description("Duplicate")]
        Duplicate = 300,
        [Description("Invalid Model")]
        InvalidModel = 303,
        [Description("Invalid User")]
        Unauthorized = 401,
        [Description("Not Found")]
        NotFound = 404,
        [Description("BadRequest")]
        BadRequest = 400,
        [Description("Error code")]
        ErrorCode = 400,

    }
}
