using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChoriRey.Application.DTO;
using ChoriRey.Application.Interface;
using ChoriRey.Application.Main;
using ChoriRey.Services.WebAPIRest.Helpers;
using ChoriRey.Transversal.Common;
using ChoriRey.Transversal.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ChoriRey.Services.WebAPIRest.Controllers.API
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuariosController : Controller
    {        
        private readonly IUsuariosApplication _Application;
        private readonly AppSettings _appSettings;

        public UsuariosController(IUsuariosApplication _Application,
                                  IOptions<AppSettings> appSettings)
        {
            this._Application = _Application;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<UsuariosDTO>> response = new Response<IEnumerable<UsuariosDTO>>();

            try
            {
                response = await _Application.GetAllAsync();
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] UsuariosDTO modelDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                if (modelDto == null)
                    return BadRequest();

                response = await _Application.InsertAsync(modelDto);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UsuariosDTO modelDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                if (modelDto == null)
                    return BadRequest();

                response = await _Application.UpdateAsync(modelDto);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DelAsync(int ID)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response = await _Application.DeleteAsync(ID);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int ID)
        {
            Response<UsuariosDTO> response = new Response<UsuariosDTO>();

            try
            {
                response = await _Application.GetAsync(ID);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetLoginAsync([FromBody] UsuariosDTO userDto)
        {
            var response = await _Application.GetLoginAsync(userDto);

            if (response.IsSuccess)
            {
                response.Data.Token = BuildToken(response);
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        private string BuildToken(Response<UsuariosDTO> usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDto.Data.Nombres)
                }),

                //Expires = DateTime.UtcNow.AddMinutes(1),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.IsSuer,
                Audience = _appSettings.Audience

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

    }
}
