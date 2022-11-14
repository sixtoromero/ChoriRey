using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChoriRey.Services.WebAPIRest.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllAsync()
        {
            return Ok("hola mundo");
        }
    }
}
