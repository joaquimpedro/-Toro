using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Exceptions;
using Toro.Application.Interfaces;
using Toro.Application.Response.common;
using Toro.Domain.Entities;

namespace Toro.Application.Features.Stock
{
    public class OrderStockCommandHandler : IRequestHandler<OrderStockCommand, BaseResponse<string>>
    {
        private readonly IStockRepository _repository;
        private readonly ITraderRepository _traderRepository;

        public OrderStockCommandHandler(IStockRepository repository, ITraderRepository traderRepository)
        {
            _repository = repository;
            _traderRepository = traderRepository;
        }

        public async Task<BaseResponse<string>> Handle(OrderStockCommand request, CancellationToken cancellationToken)
        {

            // calcular o total das ações desejadas
            // pegar o saldo do trader logado
            // verificar se o trader tem saldo suficiente
            // registrar a compra:
            //     salvar as ações compradas
            //     debitar do saldo

            var stock = await _repository.GetBySymbol(request.Symbol);

            if(stock is null)
            {
                return await Task.FromResult(new BaseResponse<string>() { Error = true, ErrorMessage = "ativo inválido" });
            }

            var totalAmount = stock.CurrentPrice * request.Amount;

            var trader = await _traderRepository.GetById(1);

            if (trader.Amount < totalAmount)
            {
                return await Task.FromResult(new BaseResponse<string>() { Error = true, ErrorMessage = "saldo insuficiente" });
            } 

            var financialAsset = trader.FinancialAssets.Find(f => f.Stock.Symbol == stock.Symbol);

            if(financialAsset is null)
            {
                financialAsset = new FinancialAsset
                {
                    Amount = request.Amount,
                    Stock = stock,
                    UnitPrice = stock.CurrentPrice,
                    Trader = trader
                };
                trader.FinancialAssets.Add(financialAsset);

            } else
            {
                trader.FinancialAssets.FindAll(f => f.Stock.Symbol == stock.Symbol).ForEach(f => f.Amount += request.Amount);
            }

            trader.Amount -= totalAmount;

            await _traderRepository.Update(trader);

            return await Task.FromResult(new BaseResponse<string>("sucesso"));
        }
    }
}
