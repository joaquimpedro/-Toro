using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Exceptions;
using Toro.Application.Features.Stock;
using Toro.Persistence.Repositories;
using Xunit;

namespace Toro.Tests.Features.Stock
{
    public class OrderStockCommandHandlerTestShould
    {

        [Theory]
        [InlineData("a", 3)]
        [InlineData("b", 2)]
        [InlineData("c", 1)]
        public async Task Handle_OrderStockCommand_WithSuccess(string symbol, int amount)
        {
            //Mockar o repositorio. O repositório, hoje, é estático mas deveria se conectar num db.

            var request = new OrderStockCommand
            {
                Symbol = symbol,
                Amount = amount
            };
            var query = new OrderStockCommandHandler(new StockRepository(), new TraderRepository());

            var result = await query.Handle(request, new CancellationToken());

            Assert.Equal("sucesso", result);
        }

        [Theory]
        [InlineData("a", 1001)]
        [InlineData("b", 501)]
        [InlineData("c", 350)]
        public async Task Handle_OrderStockCommandWithoutInsuficientFounds_ThrowsAppException(string symbol, int amount)
        {
            //Mockar o repositorio. O repositório, hoje, é estático mas deveria se conectar num db.

            var request = new OrderStockCommand
            {
                Symbol = symbol,
                Amount = amount
            };

            var handler = new OrderStockCommandHandler(new StockRepository(), new TraderRepository());

            Func<Task> act = () => handler.Handle(request, new CancellationToken());

            var exception = await Assert.ThrowsAsync<AppException>(act);
            Assert.Equal("saldo insuficiente", exception.Message);
        }

        [Theory]
        [InlineData("ab", 1)]
        [InlineData("bc", 1)]
        [InlineData("cd", 1)]
        public async Task Handle_OrderStockCommand_WithInvalidFinancialAsset(string symbol, int amount)
        {
            //Mockar o repositorio. O repositório, hoje, é estático mas deveria se conectar num db.

            var request = new OrderStockCommand
            {
                Symbol = symbol,
                Amount = amount
            };
            var handler = new OrderStockCommandHandler(new StockRepository(), new TraderRepository());

            Func<Task> act = () => handler.Handle(request, new CancellationToken());

            var exception = await Assert.ThrowsAsync<AppException>(act);

            Assert.Equal("ativo inválido", exception.Message);
        }


    }
}
