using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexvara_ERP.Application.DTOs.Common;
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
    public class CustomerController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMasterServices _masterServices;
        public CustomerController(UserManager<ApplicationUser> userManager, IMasterServices masterServices)
        {
            _masterServices = masterServices;
            _userManager = userManager;
        }

        

        #region Create

        [HttpPost("Add-CusotmerType")]
        [Authorize]
        public async Task<IActionResult> AddCusotmerType([FromBody] CreateCustomerType dto)
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
                var data = await _masterServices.SaveCustomerTypeAsync(dto, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }


        [HttpPost("Add-IndustryType")]
        [Authorize]
        public async Task<IActionResult> AddIndustryType([FromBody] CreateIndustryType dto)
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
                var data = await _masterServices.SaveIndustryTypeAsync(dto, userId);
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
        [HttpGet("Get-ById-CusotmerType")]
        [Authorize]
        public async Task<IActionResult> GetByIdCusotmerType([FromQuery] int id)
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
                var data = await _masterServices.GetByIdCustomerTypeAsync(id);
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

        [HttpGet("Get-ById-IndustryType")]
        [Authorize]
        public async Task<IActionResult> GetByIdIndustryType([FromQuery] int id)
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
                var data = await _masterServices.GetByIdIndustryTypeAsync(id);
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
        [HttpPost("Get-List-CusotmerType")]
        [Authorize]
        public async Task<IActionResult> GetListCusotmerType([FromBody] RequestStatusResponse request)
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
                var data = await _masterServices.GetListCustomerTypeAsync(request);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }

        [HttpPost("Get-List-IndustryType")]
        [Authorize]
        public async Task<IActionResult> GetListIndustryType([FromBody] RequestStatusResponse request)
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
                var data = await _masterServices.GetListIndustryTypeAsync(request);
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
        [HttpPut("Update-CusotmerType")]
        [Authorize]
        public async Task<IActionResult> UpdateCusotmerType([FromBody] UpdateCustomerType dto)
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
                var data = await _masterServices.UpdateCustomerTypeAsync(dto, userId);
                return StatusCode(data.StatusCodes, data);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                return StatusCode(response.StatusCodes, response);
            }
        }

        [HttpPut("Update-IndustryType")]
        [Authorize]
        public async Task<IActionResult> UpdateIndustryType([FromBody] UpdateIndustryType dto)
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
                var data = await _masterServices.UpdateIndustryTypeAsync(dto, userId);
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

        [HttpPut("Update-Status-IndustryType")]
        [Authorize]
        public async Task<IActionResult> UpdateStatusIndustryType([FromQuery] int id)
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
                var data = await _masterServices.UpdateIndustryTypeStatusAsync(id, userId);
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
