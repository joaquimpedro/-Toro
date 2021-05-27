using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Features.Stocks;
using Toro.Application.Interfaces;
using Toro.Domain.Entities;
using Xunit;

namespace Toro.Tests.Features.Stocks
{
    public class OrderStockCommandHandlerTestShould
    {

        [Theory]
        [InlineData("a", 3)]
        [InlineData("b", 2)]
        [InlineData("c", 1)]
        public async Task Handle_OrderStockCommand_WithSuccess(string symbol, int amount)
        {

            var repository = new Mock<IStockRepository>();
            var traderRepository = new Mock<ITraderRepository>();

            var request = new OrderStockCommand
            {
                Symbol = symbol,
                Amount = amount
            };
            var query = new OrderStockCommandHandler(repository.Object, traderRepository.Object);

            repository.Setup(r => r.GetBySymbol(It.IsAny<String>())).ReturnsAsync(new Stock() {Symbol = "a", CurrentPrice = 10.0});
            traderRepository.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(new Trader() {Name = "joão", AccountAmmount = 1000, FinancialAssets = new System.Collections.Generic.List<FinancialAsset>()});

            var result = await query.Handle(request, new CancellationToken());

            Assert.False(result.Error);
            Assert.Equal("sucesso", result.Data);
        }

        [Theory]
        [InlineData("a", 1001)]
        [InlineData("b", 501)]
        [InlineData("c", 350)]
        public async Task Handle_OrderStockCommandWithoutInsuficientFounds_ThrowsAppException(string symbol, int amount)
        {
            var repository = new Mock<IStockRepository>();
            var traderRepository = new Mock<ITraderRepository>();

            var request = new OrderStockCommand
            {
                Symbol = symbol,
                Amount = amount
            };

            repository.Setup(r => r.GetBySymbol(It.IsAny<String>())).ReturnsAsync(new Stock() { Symbol = "a", CurrentPrice = 10.0 });
            traderRepository.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(new Trader() { Name = "joão", AccountAmmount = 0, FinancialAssets = new System.Collections.Generic.List<FinancialAsset>() });

            var handler = new OrderStockCommandHandler(repository.Object, traderRepository.Object);

            var result = await handler.Handle(request, new CancellationToken());

            Assert.True(result.Error);
            Assert.Equal("saldo insuficiente", result.ErrorMessage);
        }

        [Theory]
        [InlineData("ab", 1)]
        [InlineData("bc", 1)]
        [InlineData("cd", 1)]
        public async Task Handle_OrderStockCommand_WithInvalidFinancialAsset(string symbol, int amount)
        {
            var repository = new Mock<IStockRepository>();
            var traderRepository = new Mock<ITraderRepository>();

            var request = new OrderStockCommand
            {
                Symbol = symbol,
                Amount = amount
            };

            repository.Setup(r => r.GetBySymbol(It.IsAny<String>())).ReturnsAsync( () => null);
            traderRepository.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(new Trader() { Name = "joão", AccountAmmount = 0, FinancialAssets = new System.Collections.Generic.List<FinancialAsset>() });

            var handler = new OrderStockCommandHandler(repository.Object, traderRepository.Object);

            var result = await handler.Handle(request, new CancellationToken());

            Assert.True(result.Error);
            Assert.Equal("ativo inválido", result.ErrorMessage);
        }


    }
}
