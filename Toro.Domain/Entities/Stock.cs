using System;
using System.Collections.Generic;
using System.Text;
using Toro.Domain.Commons;

namespace Toro.Domain.Entities
{
    public class Stock : BaseEntity
    {
        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }

    }
}
