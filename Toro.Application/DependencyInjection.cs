using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Toro.Application
{
    public static class DependencyInjection
    {

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

    }
}
