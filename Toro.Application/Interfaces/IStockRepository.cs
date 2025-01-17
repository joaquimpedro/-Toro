﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toro.Domain.Entities;

namespace Toro.Application.Interfaces
{
    public interface IStockRepository
    {
        public Task<Stock> GetBySymbol(string symbol);
        public Task<List<Stock>> GetTrends();
      
    }
}
