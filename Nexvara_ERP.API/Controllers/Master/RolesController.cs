using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
using Nexvara_ERP.Application.DTOs.Sales.CreateDto;
using Nexvara_ERP.Application.DTOs.Sales.UpdateDto;
using Nexvara_ERP.Application.Interface.IServices;
using Nexvara_ERP.Core;
using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Identiy;

namespace Nexvara_ERP.API.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRolesServices _rolesServices;
        public RolesController(UserManager<ApplicationUser> userManager, IRolesServices rolesServices)
        {
            _rolesServices = rolesServices;
            _userManager = userManager;
        }

        #region Create

        [HttpPost("Add-Department")]
        [Authorize]
        public async Task<IActionResult> AddDepartment([FromBody] CreateDepartment dto)
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
                var data = await _rolesServices.SaveDepartmentAsync(dto, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }

        [HttpPost("Add-Designation")]
        [Authorize]
        public async Task<IActionResult> AddDesignation([FromBody] CreateDesignation dto)
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
                var data = await _rolesServices.SaveDesignationAsync(dto, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }

        #endregion



        #region GetById
        [HttpGet("Get-ById-Department")]
        [Authorize]
        public async Task<IActionResult> GetByIdDepartment([FromQuery] int id)
        {
            var response = new ResponseDepartment<object>();
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
                var data = await _rolesServices.GetByIdDepartmentAsync(id);
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
        [HttpGet("Get-ById-Designation")]
        [Authorize]
        public async Task<IActionResult> GetByIdDesignation([FromQuery] int id)
        {
            var response = new ResponseDesignation<object>();
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
                var data = await _rolesServices.GetByIdDesignationAsync(id);
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
        #endregion


        #region GetList
        [HttpPost("Get-List-Department")]
        [Authorize]
        public async Task<IActionResult> GetListDepartment([FromBody] RequestStatusResponse request)
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
                var data = await _rolesServices.GetListDepartmentAsync(request);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }
        [HttpPost("Get-List-Designation")]
        [Authorize]
        public async Task<IActionResult> GetListDesignation([FromBody] RequestStatusResponse request)
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
                var data = await _rolesServices.GetListDesignationAsync(request);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }

        #endregion



        #region Update
        [HttpPut("Update-Department")]
        [Authorize]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartment dto)
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
                var data = await _rolesServices.UpdateDepartmentAsync(dto, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }
        [HttpPut("Update-Designation")]
        [Authorize]
        public async Task<IActionResult> UpdateDesignation([FromBody] UpdateDesignation dto)
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
                var data = await _rolesServices.UpdateDesignationAsync(dto, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }

        #endregion



        #region UpdateStatus

        [HttpPut("Update-Status-Department")]
        [Authorize]
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
                var data = await _rolesServices.UpdateDepartmentStatusAsync(id, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }
        [HttpPut("Update-Status-Designation")]
        [Authorize]
        public async Task<IActionResult> UpdateStatusDesignation([FromQuery] int id)
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
                var data = await _rolesServices.UpdateDesignationStatusAsync(id, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }
        #endregion
    }
}
