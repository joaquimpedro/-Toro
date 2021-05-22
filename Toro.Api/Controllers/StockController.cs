using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Toro.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpGet("trends")]
        public async Task<IActionResult> Trends()
        {
            return Ok("Ola mundo");
        }

        [HttpGet("order")]
        public async Task<IActionResult> OrderStock()
        {
            return Ok("Ola mundo");
        }
    }
}
