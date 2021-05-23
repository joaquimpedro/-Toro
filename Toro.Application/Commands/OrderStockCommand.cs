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
    public class OrderStockCommand : IRequest
    {
        public string symbol { get; set; }
        public int amount { get; set; }
    }

    public class OrderStockCommandHandler : IRequestHandler<OrderStockCommand>
    {
        public Task<Unit> Handle(OrderStockCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
