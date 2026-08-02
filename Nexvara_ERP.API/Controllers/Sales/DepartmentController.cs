using Microsoft.AspNetCore.Mvc;
using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
using Nexvara_ERP.Application.Interface.IServices;
using Nexvara_ERP.Core;
using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Identiy;

namespace Nexvara_ERP.API.Controllers.Sales
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class DepartmentController :ControllerBase
    {
        private readonly IDepartmentServices _departmentService;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;

        public DepartmentController(IDepartmentServices departmentServices, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager)
        {
            _departmentService = departmentServices;
            _userManager = userManager;
        }
        [HttpPost(("Add-Department"))]

        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentDto dto)
        {
            var response = new BaseResponse();
            var userId = _userManager.GetUserId(User);
            try
            {
                if (userId == null)
                {
                    response.Message = SystemMessage.UnAuthorized;
                    response.StatusCodes = (int)ResponseCodes.Unauthorized;
                    return StatusCode(response.StatusCodes, response);
                }
                if (dto == null)
                {
                    response.Message = SystemMessage.RequestbodyNull;
                    response.StatusCodes = (int)ResponseCodes.BadRequest;
                    return StatusCode(response.StatusCodes, response);
                }
                var data = await _departmentService.SaveAsync(dto, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }
        [HttpGet("Get-ById-Company")]

        public async Task<IActionResult> GetByIdDepartment([FromQuery] int id)
        {
            var response = new DepatmentDto<object>();
            var userId = _userManager.GetUserId(User);
            try
            {
                if (userId == null)
                {
                    response.Success = false;
                    response.Message = SystemMessage.UnAuthorized;
                    response.Data = null;
                    response.StatusCodes = (int)ResponseCodes.Unauthorized;
                    return StatusCode(response.StatusCodes, response);
                }
                if (id <= 0)
                {
                    response.Success = false;
                    response.Message = SystemMessage.RequiredId;
                    response.Data = null;
                    response.StatusCodes = (int)ResponseCodes.BadRequest;
                    return StatusCode(response.StatusCodes, response);
                }
                var data = await _departmentService.GetByIdDepartmentAsync(id);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }
        [HttpPost("Get-List-Company")]

        public async Task<IActionResult> GetListCompany([FromBody] RequestStatusResponse request)
        {
            var response = new BaseResponse();
            var userId = _userManager.GetUserId(User);
            try
            {
                if (userId == null)
                {
                    response.Message = SystemMessage.UnAuthorized;
                    response.StatusCodes = (int)ResponseCodes.Unauthorized;
                    return StatusCode(response.StatusCodes, response);
                }
                if (request == null)
                {
                    response.Message = SystemMessage.RequestbodyNull;
                    response.StatusCodes = (int)ResponseCodes.BadRequest;
                    return StatusCode(response.StatusCodes, response);
                }
                var data = await _departmentService.GetListDepartmentAsync(request);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }

        [HttpPut("Update-Company")]

        public async Task<IActionResult> UpdateCompany([FromBody] UpdateDepartmentDto dto)
        {
            var response = new BaseResponse();
            var userId = _userManager.GetUserId(User);
            try
            {
                if (userId == null)
                {
                    response.Message = SystemMessage.UnAuthorized;
                    response.StatusCodes = (int)ResponseCodes.Unauthorized;
                    return StatusCode(response.StatusCodes, response);
                }
                if (dto == null)
                {
                    response.Message = SystemMessage.RequestbodyNull;
                    response.StatusCodes = (int)ResponseCodes.BadRequest;
                    return StatusCode(response.StatusCodes, response);
                }
                var data = await _departmentService.UpdateAsync(dto, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }


        [HttpPut("Update-Status-Company")]

        public async Task<IActionResult> UpdateStatusDepartment([FromQuery] int id)
        {
            var response = new BaseResponse();
            var userId = _userManager.GetUserId(User);
            try
            {
                if (userId == null)
                {
                    response.Message = SystemMessage.UnAuthorized;
                    response.StatusCodes = (int)ResponseCodes.Unauthorized;
                    return StatusCode(response.StatusCodes, response);
                }
                if (id <= 0)
                {
                    response.Message = SystemMessage.RequiredId;
                    response.StatusCodes = (int)ResponseCodes.BadRequest;
                    return StatusCode(response.StatusCodes, response);
                }
                var data = await _departmentService.UpdateStatusAsync(id, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }



    }
}
