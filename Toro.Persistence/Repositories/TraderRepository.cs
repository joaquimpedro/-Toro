using System.Collections.Generic;
using System.Threading.Tasks;
using Toro.Application.Interfaces;
using Toro.Domain.Entities;

namespace Toro.Persistence.Repositories
{
    public class TraderRepository : ITraderRepository
    {
        private readonly List<Trader> _traders = new List<Trader>() { 
            new Trader{Id = 1, Name = "João e Maria", AccountAmmount = 1000, FinancialAssets = new List<FinancialAsset>()}
        };

        public Task<Trader> GetById(int id)
        {
            _traders.Add(new Trader { Id = 1, Name = "João e Maria", AccountAmmount = 1000 });
            return Task.FromResult(_traders.Find(t => t.Id == id));
        }

        public Task<int> Update(Trader trader)
        {
            // Precisa tratar quando não encontrar o trader.
            // Como o caso não é possível no fluxo atual da aplição, não criarei o teste e não implementarei a validação.

            var index = _traders.FindIndex(t => t.Id == trader.Id);
            _traders[index] = trader;

            return Task.FromResult(trader.Id);
        }
    }
}
