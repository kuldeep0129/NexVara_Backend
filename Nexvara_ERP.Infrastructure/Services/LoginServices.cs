using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Nexvara_ERP.Application.DTOs;
using Nexvara_ERP.Application.Interface.IServices;
using Nexvara_ERP.Core;
using Nexvara_ERP.Core.Common;
using Nexvara_ERP.Domain.Data;
using Nexvara_ERP.Domain.Identiy;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Infrastructure.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public LoginServices(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
        {
            var response = new LoginResponseDto();
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                response.Message = SystemMessage.NotFindEmail;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                response.Data = null;
                return response;
            }
            var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordValid)
            {
                response.Message = SystemMessage.NotFindPassword;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                response.Data = null;
                return response;
            }
            var roles = await _userManager.GetRolesAsync(user);
            var token = GenerateToken(user.Id.ToString(), user.Email!, roles);
            if (token == null)
            {
                response.Message = SystemMessage.NotGenrateToke;
                response.StatusCodes = (int)ResponseCodes.BadRequest;
                response.Data = null;
                return response;
            }
            response.Message = SystemMessage.LoginSuccess;
            response.StatusCodes = (int)ResponseCodes.Success;
            response.Data = token;
            return response;
        }


        private string GenerateToken(string id, string email, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                    new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(JwtRegisteredClaimNames.Sub,id),
                new Claim(JwtRegisteredClaimNames.Email,email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(
      Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
