using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Toro.Api.Controllers;
using Toro.Application.Features.Stocks;
using Toro.Application.Features.Traders;
using Toro.Application.Response.common;
using Toro.Application.Response.Stock;
using Toro.Application.Response.Trader;
using Xunit;

namespace Toro.Tests.Controllers
{
    public class TraderControllerTestShould
    {
        [Fact]
        public async Task GetTrader_AndReturnOk()
        {
            var mediator = new Mock<IMediator>();
            var controller = new TraderController();
            var response = await Task.FromResult(new BaseResponse<TraderResponse>(
                new TraderResponse { Name = "João", AccountAmmount = 1000, FinancialAssets = new List<FinancialAssetsResponse>() }
            ));

            mediator.Setup(m => m.Send(It.IsAny<GetTraderByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(() => response);

            var result = await controller.GetTrader(1, mediator.Object);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<TraderResponse>(okResult.Value);
        }

        [Fact]
        public async Task OrderStock_WithInvaidId_ReturnNotFound()
        {
            var mediator = new Mock<IMediator>();
            var controller = new TraderController();
            var response = await Task.FromResult(new BaseResponse<string>("sucesso"));

            mediator.Setup(m => m.Send(It.IsAny<GetTraderByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(() => null);

            var result = await controller.GetTrader(1, mediator.Object);

            Assert.IsType<NotFoundResult>(result);
            
        }
    }
}
