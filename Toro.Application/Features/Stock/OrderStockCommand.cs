using MediatR;
using Toro.Application.Response.common;

namespace Toro.Application.Features.Stock
{
    public class OrderStockCommand : IRequest<BaseResponse<string>>
    {
        public string Symbol { get; set; }
        public int Amount { get; set; }
    }
}
