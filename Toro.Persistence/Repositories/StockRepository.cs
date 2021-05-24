using System.Collections.Generic;
using System.Threading.Tasks;
using Toro.Application.Interfaces;
using Toro.Domain.Entities;

namespace Toro.Persistence.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly List<Stock> _trendStocks = new List<Stock>() { 
            new Stock{Symbol = "a", CurrentPrice = 1},
            new Stock{Symbol = "b", CurrentPrice = 2},
            new Stock{Symbol = "c", CurrentPrice = 3},
            new Stock{Symbol = "d", CurrentPrice = 4},
            new Stock{Symbol = "e", CurrentPrice = 5}
        };

        public Task<Stock> GetBySymbol(string symbol)
        {
            return Task.FromResult(_trendStocks.Find(s => s.Symbol.Equals(symbol)));
        }

        public Task<List<Stock>> GetTrends()
        {
            return Task.FromResult(_trendStocks);
        }
    }
}
