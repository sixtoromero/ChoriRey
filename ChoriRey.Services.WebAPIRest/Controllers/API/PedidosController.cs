using ChoriRey.Application.DTO;
using ChoriRey.Application.Interface;
using ChoriRey.Services.WebAPIRest.Helpers;
using ChoriRey.Transversal.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ChoriRey.Services.WebAPIRest.Controllers.API
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly IEncabezadoPedidoApplication _Application;
        private readonly AppSettings _appSettings;

        public PedidosController(IEncabezadoPedidoApplication _Application,
                                  IOptions<AppSettings> appSettings)
        {
            this._Application = _Application;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> GenerarPedidoAsync([FromBody] EncabezadoPedidoDTO modelDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                if (modelDto == null)
                    return BadRequest();

                response = await _Application.GenerarPedidoAsync(modelDto);
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

    }
}
