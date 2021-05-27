using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Toro.Application.Features.Traders;

namespace Toro.Api.Controllers
{
    [Route("api/trader")]
    [ApiController]
    public class TraderController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrader(int id, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new GetTraderByIdQuery(id));

            if(result is null)
            {
                return NotFound();
            }

            if (result.Error)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Data);
        }

    }
}