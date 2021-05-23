using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Queries;
using Toro.Application.Response;

namespace Toro.Domain.Commands
{
    public class OrderStockCommand : IRequest<string>
    {
        public string symbol { get; set; }
        public int amount { get; set; }
    }

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
