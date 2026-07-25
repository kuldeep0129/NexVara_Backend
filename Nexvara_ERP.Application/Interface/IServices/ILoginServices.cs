using Nexvara_ERP.Application.DTOs;
using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.Interface.IServices
{
    public interface ILoginServices
    {
        Task<LoginResponseDto> LoginAsync(LoginDto dto);
    }
}
