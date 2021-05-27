using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Interfaces;
using Toro.Application.Response.common;
using Toro.Application.Response.Stock;

namespace Toro.Application.Features.Stocks
{
    public class GetTrendStocksQueryHandler : IRequestHandler<GetTrendStocksQuery, BaseResponse<List<StockResponse>>>
    {

        private readonly IStockRepository _repository;

        public GetTrendStocksQueryHandler(IStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<List<StockResponse>>> Handle(GetTrendStocksQuery request, CancellationToken cancellationToken)
        {
            var trends = await _repository.GetTrends();
            var result = new List<StockResponse>();

            foreach (var stock in trends)
            {
                // Poderia usar dto/map e fazer a conversão automatica.
                result.Add(new StockResponse { Symbol = stock.Symbol, CurrentPrice = stock.CurrentPrice });
            }

            var response = new BaseResponse<List<StockResponse>>(result);

            return response;
        }
    }
}
