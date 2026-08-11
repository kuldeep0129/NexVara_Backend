using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
using Nexvara_ERP.Application.DTOs.Sales.CreateDto;
using Nexvara_ERP.Application.DTOs.Sales.UpdateDto;
using Nexvara_ERP.Application.Interface.IServices;
using Nexvara_ERP.Core;
using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Identiy;

namespace Nexvara_ERP.API.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class LeadSourcesController : ControllerBase
    {
        private readonly ILeadSourcesServices _leadSourcesServices;
        private readonly UserManager<ApplicationUser> _userManager;
        public LeadSourcesController(ILeadSourcesServices leadSourcesServices, UserManager<ApplicationUser> userManager)
        {
            _leadSourcesServices = leadSourcesServices;
            _userManager = userManager;
        }
        #region Create

        [HttpPost("Add-LeadSource")]
        [Authorize]
        public async Task<IActionResult> AddLeadSource([FromBody] AddLeadSourcesDto dto)
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
                var data = await _leadSourcesServices.SaveAsync(dto, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }

        [HttpPost("Add-LeadStatus")]
        [Authorize]
        public async Task<IActionResult> AddLeadStatus([FromBody] CreateLeadStatus dto)
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
                var data = await _leadSourcesServices.SaveLeadStatusAsync(dto, userId);
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
        [HttpGet("Get-ById-LeadSource")]
        [Authorize]
        public async Task<IActionResult> GetByIdLeadSource([FromQuery] int id)
        {
            var response = new LeadSourcesResponseDto<object>();
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
                var data = await _leadSourcesServices.GetByIdLeadSourcesAsync(id);
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
        [HttpGet("Get-ById-LeadStatus")]
        [Authorize]
        public async Task<IActionResult> GetByIdLeadStatus([FromQuery] int id)
        {
            var response = new LeadStatusResponseDto<object>();
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
                var data = await _leadSourcesServices.GetByIdLeadStatusAsync(id);
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
        [HttpPost("Get-List-LeadStatus")]
        [Authorize]
        public async Task<IActionResult> GetListLeadStatus([FromBody] RequestStatusResponse request)
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
                var data = await _leadSourcesServices.GetListLeadStatusAsync(request);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }
        [HttpPost("Get-List-LeadSource")]
        [Authorize]
        public async Task<IActionResult> GetListLeadSource([FromBody] RequestStatusResponse request)
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
                var data = await _leadSourcesServices.GetListLeadSourcesAsync(request);
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
        [HttpPut("Update-LeadSource")]
        [Authorize]
        public async Task<IActionResult> UpdateLeadSource([FromBody] UpdateLeadSourcesDto dto)
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
                var data = await _leadSourcesServices.UpdateAsync(dto, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }
        [HttpPut("Update-LeadStatus")]
        [Authorize]
        public async Task<IActionResult> UpdateLeadStatus([FromBody] UpdateLeadStatus dto)
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
                var data = await _leadSourcesServices.UpdateLeadStatusAsync(dto, userId);
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

        [HttpPut("Update-Status-LeadSource")]
        [Authorize]
        public async Task<IActionResult> UpdateStatusLeadSource([FromQuery] int id)
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
                var data = await _leadSourcesServices.UpdateStatusAsync(id, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }
        [HttpPut("Update-Status-LeadStatus")]
        [Authorize]
        public async Task<IActionResult> UpdateStatusLeadStatus([FromQuery] int id)
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
                var data = await _leadSourcesServices.UpdateLeadStatusStatusAsync(id, userId);
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
