using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexvara_ERP.Application.DTOs;
using Nexvara_ERP.Application.Interface.IServices;
using Nexvara_ERP.Core;

namespace Nexvara_ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginServices _loginServices;
        public AccountController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAccount([FromBody] LoginDto dto)
        {
            var response = new LoginResponseDto();
            if(dto == null)
            {
                response.Message = SystemMessage.RequestbodyNull;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                response.Data = null;
                return StatusCode(response.StatusCodes,response);
            }

            var data = await _loginServices.LoginAsync(dto);
            return StatusCode(data.StatusCodes, data);

        }
    }
}
