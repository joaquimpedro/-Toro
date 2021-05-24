using Toro.Application.Interfaces;
using Toro.Persistence.Repositories;
using Xunit;

namespace Toro.Tests.Repositories
{
    public class TraderRepositoryTestShould
    {
        private readonly ITraderRepository _repository = new TraderRepository();

        [Fact]
        public async void GetById_IDValid_ReturnTrader()
        {
            var trader = await _repository.GetById(1);

            Assert.NotNull(trader);
            Assert.Equal("João e Maria", trader.Name);
        }

        [Fact]
        public async void GetById_IDInvalid_ReturnNull()
        {
            var trader = await _repository.GetById(100);

            Assert.Null(trader);
        }

        [Fact]
        public async void Update_ChangeName_ReturnTraderId()
        {
            var trader = await _repository.GetById(1);
            trader.Name = "novo nome";
            trader.Amount = 50;
            var result =  await _repository.Update(trader);

            Assert.Equal(1, result);

            var reloadedObject = await _repository.GetById(1);
            Assert.Equal(trader.Name, reloadedObject.Name);
            Assert.Equal(trader.Amount, reloadedObject.Amount);
        }

        // Precisa do teste quando não encontrar o id.
        // Como o caso não é possível no fluxo atual da aplição, não criarei o teste e não implementarei a validação.

    }
}
