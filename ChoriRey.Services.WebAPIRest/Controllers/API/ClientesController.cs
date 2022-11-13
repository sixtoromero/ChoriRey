using System;
//using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
//using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AdsPublisher.Application.DTO;
using AdsPublisher.Application.Interface;
using AdsPublisher.Services.WebAPIRest.Helpers;
using AdsPublisher.Transversal.Common;
using AdsPublisher.Transversal.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AdsPublisher.Services.WebAPIRest.Controllers.api
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly IClientesApplication _clienteApplication;
        private readonly AppSettings _appSettings;
        public static IWebHostEnvironment _environment;
        
        public ClientesController(IClientesApplication clienteApplication, 
                                  IOptions<AppSettings> appSettings,
                                  IWebHostEnvironment environment)
        {
            _clienteApplication = clienteApplication;
            _appSettings = appSettings.Value;
            _environment = environment;

        }        

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetLoginAsync([FromBody]ClientesDTO clienteDto)
        {
            var response = await _clienteApplication.GetLoginAsync(clienteDto.Correo, clienteDto.Password);

            if (response.IsSuccess)
            {
                response.Data.Token = BuildToken(response);
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetLoginInvitadoAsync()
        {            
            var response = new Response<string>();
            try
            {
                response.Data = BuildTokenInvitado();
                response.IsSuccess = true;
                response.Message = string.Empty;
                return Ok(response);
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
        public async Task<IActionResult> InsertAsync([FromBody]ClientesDTO clienteDto)
        {
            if (clienteDto == null)
                return BadRequest();

            var response = await _clienteApplication.InsertAsync(clienteDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        //[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SendMailAsync([FromBody]ClientesDTO clienteDto)
        {
            if (clienteDto == null)
                return BadRequest();

            var response = await _clienteApplication.SendMailAsync(clienteDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromBody]ClientesDTO clienteDto)
        {
            if (clienteDto == null)
                return BadRequest();

            var response = await _clienteApplication.UpdateAsync(clienteDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _clienteApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        public IActionResult GetConsulta()
        {
            return Ok("OK");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetActivation(string email)
        {
            var response = await _clienteApplication.SetActivation(email);
            //return Ok(response);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [AllowAnonymous]
        [HttpPost]
        //public async Task<IActionResult> FileUpload([FromForm]FileUploadAPI image)
        public async Task<IActionResult> FileUpload([FromForm]FileUploadAPI file)
        {
            string jsonValue = Request.Headers["jsonValue"];

            //string.TryParse(IDClienteHeader, out int IDCliente);

            Response<string> resp = new Response<string>();
            
            resp.IsSuccess = false;
            resp.Message = string.Empty;

            try
            {
                if (file.files != null)
                {
                    if (file.files.Length > 0)
                    {
                        if (!Directory.Exists(_environment.ContentRootPath + "\\Upload\\"))
                        {
                            Directory.CreateDirectory(_environment.ContentRootPath + "\\Upload\\");
                        }

                        using (FileStream fileStream = System.IO.File.Create(_environment.ContentRootPath + "\\Upload\\" + file.files.FileName))
                        {
                            await file.files.CopyToAsync(fileStream);
                            fileStream.Flush();

                            resp.Data = "\\Upload\\" + file.files.FileName;
                            resp.IsSuccess = true;
                            resp.Message = string.Empty;
                            
                            var result = await _clienteApplication.GetAsync(IDCliente);

                            if (result.IsSuccess)
                            {
                                ClientesDTO clienteDto = new ClientesDTO();
                                clienteDto = result.Data;
                                clienteDto.Foto = file.files.FileName;

                                var response = await _clienteApplication.UpdateAsync(clienteDto);
                                if (response.IsSuccess)
                                {
                                    return Ok(resp);
                                }
                                else
                                {
                                    return BadRequest(response.Message);
                                }
                            } else
                            {
                                resp.Data = null;
                                resp.IsSuccess = false;
                                resp.Message = "Ha ocurrido un error al actualizar la foto de perfil.";
                            }

                            return Ok(resp);
                        }
                    }
                    else
                    {
                        resp.Data = null;
                        resp.IsSuccess = false;
                        resp.Message = "Al parecer no has seleccionado ningún archivo a cargar.";

                        return BadRequest(resp);
                    }
                }else
                {
                    resp.Data = null;
                    resp.IsSuccess = false;
                    resp.Message = "El valor de file es nulo";

                    return BadRequest(resp);
                }            
            }
            catch (Exception ex)
            {
                resp.Data = null;
                resp.IsSuccess = true;
                resp.Message = ex.Message.ToString();

                return BadRequest(resp);
            }
            
        }

        private string BuildToken(Response<ClientesDTO> usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDto.Data.IDCliente.ToString())
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

        private string BuildTokenInvitado()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "0")
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