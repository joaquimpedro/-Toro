using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Interfaces;
using Toro.Application.Response.common;
using Toro.Application.Response.Trader;

namespace Toro.Application.Features.Traders
{
    public class GetTraderByIdQueryHandler : IRequestHandler<GetTraderByIdQuery, BaseResponse<TraderResponse>>
    {

        private readonly ITraderRepository _traderRepository;

        public GetTraderByIdQueryHandler(ITraderRepository traderRepository)
        {
            _traderRepository = traderRepository;
        }

        public async Task<BaseResponse<TraderResponse>> Handle(GetTraderByIdQuery request, CancellationToken cancellationToken)
        {
            var trader = await _traderRepository.GetById(request.Id);

            if(trader is null)
            {
                return null;
            }

            var response = new TraderResponse()
            {
                Name = trader.Name,
                AccountAmmount = trader.AccountAmmount,
                FinancialAssets = trader.FinancialAssets != null ? trader.FinancialAssets.Select(f => new FinancialAssetsResponse()
                {
                    Symbol = f.Stock.Symbol,
                    Amount = f.Amount,
                    UnitPrice = f.Stock.CurrentPrice
                }).ToList() : null
            };

            return await Task.FromResult(new BaseResponse<TraderResponse>() { Data = response });
        }
    }
}
