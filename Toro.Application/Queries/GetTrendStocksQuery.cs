using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Response;

namespace Toro.Application.Queries
{
    public class GetTrendStocksQuery : IRequest<List<StockResponse>>
    {
    }

    public class GetTrendStocksQueryHandler : IRequestHandler<GetTrendStocksQuery, List<StockResponse>>
    {
        public Task<List<StockResponse>> Handle(GetTrendStocksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
