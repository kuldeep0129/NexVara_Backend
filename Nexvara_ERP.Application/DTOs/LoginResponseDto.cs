using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs
{
    public class LoginResponseDto : BaseResponse
    {
        public  string? Data { get; set; }
        public string? Role { get; set; }
    }
}
