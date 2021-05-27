using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toro.Application.Response.Trader
{
    public class FinancialAssetsResponse
    {
        public string Symbol { get; set; }
        public int Amount { get; set; }
        public double UnitPrice { get; set; }
    }
}
