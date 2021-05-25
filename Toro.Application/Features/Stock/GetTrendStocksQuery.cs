using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Interfaces;
using Toro.Application.Response.common;
using Toro.Application.Response.Stock;

namespace Toro.Application.Features.Stock
{
    public class GetTrendStocksQuery : IRequest<BaseResponse<List<StockResponse>>>
    {
    }

}
