using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Features.Stock;
using Toro.Persistence.Repositories;
using Xunit;

namespace Toro.Tests.Features.Stock
{
    public class GetTrendStocksQueryHandlerTest
    {
        [Fact]
        public async Task Test1()
        {
            //Mockar o repositorio. O repositório, hoje, é estático mas deveria se conectar num db.

            var request = new GetTrendStocksQuery();
            var query = new GetTrendStocksQueryHandler(new StockRepository());

            var result = await query.Handle(request, new CancellationToken());

            Assert.Equal(5, result.Data.Count);
        }
    }
}
