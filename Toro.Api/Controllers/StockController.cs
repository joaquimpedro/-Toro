using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Toro.Application.Queries;
using Toro.Domain.Commands;

namespace Toro.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpGet("trends")]
        public async Task<IActionResult> Trends([FromServices] IMediator mediator)  
        {
            var result = await mediator.Send(new GetTrendStocksQuery());
            return Ok(result);
        }

        [HttpGet("order")]
        public async Task<IActionResult> OrderStock(
            [FromBody] OrderStockCommand command,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return  Ok(result);
        }
    }
}
