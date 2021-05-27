using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Features.Stocks;
using Toro.Application.Interfaces;
using Toro.Domain.Entities;
using Xunit;

namespace Toro.Tests.Features.Stocks
{
    public class GetTrendStocksQueryHandlerTest
    {
        [Fact]
        public async Task GetTrends_WithSuccess()
        {
            
            var repository = new Mock<IStockRepository>();
            var request = new GetTrendStocksQuery();
            var query = new GetTrendStocksQueryHandler(repository.Object);

            var response = new List<Stock>() { new Stock() { Symbol = "a" }, new Stock() { Symbol = "b" } };

            repository.Setup(r => r.GetTrends()).ReturnsAsync(response);

            var result = await query.Handle(request, new CancellationToken());

            Assert.Equal(response.Count, result.Data.Count);
        }
    }
}
