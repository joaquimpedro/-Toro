using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Exceptions;
using Toro.Application.Interfaces;
using Toro.Domain.Entities;

namespace Toro.Application.Features.Stock
{
    public class OrderStockCommandHandler : IRequestHandler<OrderStockCommand, string>
    {
        private readonly IStockRepository _repository;
        private readonly ITraderRepository _traderRepository;
        private readonly IFinancialAssetsRepository _financialAssetsRepository;

        public OrderStockCommandHandler(IStockRepository repository, ITraderRepository traderRepository, IFinancialAssetsRepository financialAssetsRepository)
        {
            _repository = repository;
            _traderRepository = traderRepository;
            _financialAssetsRepository = financialAssetsRepository;
        }

        public async Task<string> Handle(OrderStockCommand request, CancellationToken cancellationToken)
        {

            // calcular o total das ações desejadas
            // pegar o saldo do trader
            // verificar se o trader tem saldo suficiente
            // registrar a compra:
            //     salvar as ações compradas
            //     debitar do saldo

            var stock = await _repository.GetBySymbol(request.Symbol);

            if(stock is null)
            {
                throw new AppException("ativo inválido");
            }

            var totalAmount = stock.CurrentPrice * request.Amount;

            //Passando o ID 1, mas aqui deveria pegar o Trader logado;
            var trader = await _traderRepository.GetById(1);

            if (trader.Amount < totalAmount)
            {
                throw new AppException("saldo insufiente");
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

            await _financialAssetsRepository.Add(financialAsset);
            await _traderRepository.Update(trader);
            

            return await  Task.FromResult("sucesso");
        }
    }
}
