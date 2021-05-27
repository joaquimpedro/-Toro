using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toro.Persistence.Repositories;
using Xunit;

namespace Toro.Tests.Repositories
{
    public class StockRepositoryTestShould
    {
        [Fact]
        public async void GetBySymbol_SymbolExists_ReturnStock()
        {
            var repository = new StockRepository();
            var stock = await repository.GetBySymbol("PETR4");

            Assert.NotNull(stock);
            Assert.Equal(1, stock.Id);
        }

        [Fact]
        public async void GetBySymbol_SymbolExists_ReturNull()
        {
            var repository = new StockRepository();
            var stock = await repository.GetBySymbol("QWERTY-10");

            Assert.Null(stock);
        }

        [Fact]
        public async void GetTrends_ReturnOnlyTop5Stocks()
        {
            var repository = new StockRepository();
            var trends = await repository.GetTrends();

            Assert.NotNull(trends);
            Assert.Equal(5, trends.Count);
        }

    }
}
