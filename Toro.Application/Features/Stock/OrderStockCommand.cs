using MediatR;

namespace Toro.Application.Features.Stock
{
    public class OrderStockCommand : IRequest<string>
    {
        public string symbol { get; set; }
        public int amount { get; set; }
    }
}
