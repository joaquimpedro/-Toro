using Microsoft.Extensions.DependencyInjection;
using Toro.Application.Interfaces;
using Toro.Persistence.Repositories;

namespace Toro.Persistence
{
    public static class DependencyInjection
    {

        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<IStockRepository, StockRepository>();
        }

    }
}
