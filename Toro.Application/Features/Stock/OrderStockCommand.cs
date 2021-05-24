using MediatR;

namespace Toro.Application.Features.Stock
{
    public class OrderStockCommand : IRequest<string>
    {
        public string Symbol { get; set; }
        public int Amount { get; set; }
    }
}
