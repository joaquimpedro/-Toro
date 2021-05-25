using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Toro.Application.Features.Stock;

namespace Toro.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpGet("trends")]
        public async Task<IActionResult> GetTrends([FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new GetTrendStocksQuery());

            if (result.Error)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Data);
        }

        [HttpPost("order")]
        public async Task<IActionResult> OrderStock(
            [FromBody] OrderStockCommand command,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);

            if (result.Error)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Data);
        }
    }
}