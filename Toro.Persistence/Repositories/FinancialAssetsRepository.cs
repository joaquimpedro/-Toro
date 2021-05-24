using System.Collections.Generic;
using System.Threading.Tasks;
using Toro.Application.Interfaces;
using Toro.Domain.Entities;

namespace Toro.Persistence.Repositories
{
    public class FinancialAssetsRepository : IFinancialAssetsRepository
    {
        private readonly List<FinancialAsset> _financialAssets = new List<FinancialAsset>();

        public Task<FinancialAsset> Add(FinancialAsset financialAsset)
        {
            financialAsset.Id = _financialAssets.Count + 1;

            _financialAssets.Add(financialAsset);

            return Task.FromResult(financialAsset);
        }
    }
}
