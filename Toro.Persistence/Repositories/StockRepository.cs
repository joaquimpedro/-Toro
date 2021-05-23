using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toro.Application.Interfaces;
using Toro.Domain.Entities;

namespace Toro.Persistence.Repositories
{
    public class StockRepository : IStockRepository
    {
        public List<Stock> GetTrends()
        {
            throw new NotImplementedException();
        }
    }
}
