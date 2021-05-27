using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toro.Api.Controllers;
using Toro.Application.Features.Stocks;
using Toro.Application.Response.common;
using Toro.Application.Response.Stock;
using Xunit;

namespace Toro.Tests.Controllers
{
    public class StockControllerTestShould
    {
        [Fact]
        public async Task GetTrends_AndReturnOKWithStocks()
        {
            var mediator = new Mock<IMediator>();
            var controller = new StockController();
            var response =  await Task.FromResult(new BaseResponse<List<StockResponse>>(new List<StockResponse> {
                new StockResponse { Symbol = "A", CurrentPrice = 1 }
            }));

            mediator.Setup(m => m.Send(It.IsAny<GetTrendStocksQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

            var result = await controller.GetTrends(mediator.Object);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<StockResponse>>(okResult.Value);
        }

        [Fact]
        public async Task OrderStock_WithValidRequest_ReturnOk()
        {
            var mediator = new Mock<IMediator>();
            var controller = new StockController();
            var command = new OrderStockCommand();
            var response = await Task.FromResult(new BaseResponse<string>("sucesso"));


            mediator.Setup(m => m.Send(It.IsAny<OrderStockCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

            var result = await controller.OrderStock(command, mediator.Object);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(response.Data, okResult.Value);
        }

        [Fact]
        public async Task OrderStock_WithInvalidRequest_ReturnBadRequest()
        {
            var mediator = new Mock<IMediator>();
            var controller = new StockController();
            var command = new OrderStockCommand();
            var response = await Task.FromResult(new BaseResponse<string>() { Error = true, ErrorMessage = "error" });

            mediator.Setup(m => m.Send(It.IsAny<OrderStockCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

            var result = await controller.OrderStock(command, mediator.Object);

            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(response.ErrorMessage, badRequestObjectResult.Value);
        }

    }
}
