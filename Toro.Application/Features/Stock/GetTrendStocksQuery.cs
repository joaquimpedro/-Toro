using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Interfaces;
using Toro.Application.Response.Stock;

namespace Toro.Application.Features.Stock
{
    public class GetTrendStocksQuery : IRequest<List<StockResponse>>
    {
    }

}
