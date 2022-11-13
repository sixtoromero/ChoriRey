using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AdsPublisher.Services.WebAPIRest.Controllers.API
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HistorialRegistroController : Controller
    {
        private readonly IHistorialRegistroApplication _Application;
        private readonly AppSettings _appSettings;

        public HistorialRegistroController(IHistorialRegistroApplication AppApplication,
                                  IOptions<AppSettings> appSettings)
        {
            _Application = AppApplication;
            _appSettings = appSettings.Value;
        }
        //[FromBody]
        [HttpPost]
        public async Task<IActionResult> InsertAsync(Historial_RegistroDTO modelDto)
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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int ID)
        {
            Response<IEnumerable<Historial_RegistroDTO>> response = new Response<IEnumerable<Historial_RegistroDTO>>();

            try
            {
                response = await _Application.GetAllAsync(ID);
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
    }
}