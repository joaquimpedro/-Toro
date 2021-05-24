using System.Collections.Generic;
using System.Threading.Tasks;
using Toro.Application.Interfaces;
using Toro.Domain.Entities;

namespace Toro.Persistence.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly List<Stock> _trendStocks = new List<Stock>() { 
            new Stock{Id = 1, Symbol = "a", CurrentPrice = 1},
            new Stock{Id = 2, Symbol = "b", CurrentPrice = 2},
            new Stock{Id = 3, Symbol = "c", CurrentPrice = 3},
            new Stock{Id = 4, Symbol = "d", CurrentPrice = 4},
            new Stock{Id = 5, Symbol = "e", CurrentPrice = 5}
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
