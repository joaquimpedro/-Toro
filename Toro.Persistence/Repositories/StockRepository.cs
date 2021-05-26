using System.Collections.Generic;
using System.Threading.Tasks;
using Toro.Application.Interfaces;
using Toro.Domain.Entities;

namespace Toro.Persistence.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly List<Stock> _trendStocks = new List<Stock>() { 
            new Stock{Id = 1, Symbol = "PETR4", CurrentPrice = 28.44},
            new Stock{Id = 2, Symbol = "MGLU3", CurrentPrice = 25.91},
            new Stock{Id = 3, Symbol = "VVAR3", CurrentPrice = 25.91},
            new Stock{Id = 4, Symbol = "SANB11", CurrentPrice = 40.77},
            new Stock{Id = 5, Symbol = "TORO4", CurrentPrice = 115.98}
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
