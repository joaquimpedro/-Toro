using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Toro.Application.Features.Stock
{
    public class OrderStockCommandHandler : IRequestHandler<OrderStockCommand, string>
    {
        public Task<string> Handle(OrderStockCommand request, CancellationToken cancellationToken)
        {

            // calcular o total das ações desejadas
            // pegar o saldo do usuario
            // verificar se o usuário tem saldo suficiente
            // registrar a compra:
            //     salvar as ações compradas
            //     debitar do saldo

            return Task.FromResult("");
        }
    }
}
