using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toro.Domain.Entities;

namespace Toro.Application.Response.Trader
{
    public class TraderResponse
    {
        public string Name { get; set; }
        public double AccountAmmount { get; set; }
        public List<FinancialAssetsResponse> FinancialAssets { get; set; }

    }
}
