using System;
using System.Collections.Generic;
using System.Text;
using Toro.Application.Response.common;

namespace Toro.Application.Response.Stock
{
    public class StockResponse
    {
        public string Symbol { get; set; }
        public double CurrentPrice { get; set; }

    }
}
