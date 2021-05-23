using System;
using System.Collections.Generic;
using System.Text;
using Toro.Domain.Commons;

namespace Toro.Domain.Entities
{
    public class Trader : BaseEntity
    {
        public string Name { get; set; }
        public decimal amount { get; set; }
        public List<FinancialAsset> FinancialAssets { get; set; }
    }
}
