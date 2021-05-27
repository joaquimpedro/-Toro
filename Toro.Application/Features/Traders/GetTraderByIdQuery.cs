using MediatR;
using System.Collections.Generic;
using Toro.Application.Response.common;
using Toro.Application.Response.Trader;

namespace Toro.Application.Features.Traders
{

    public class GetTraderByIdQuery : IRequest<BaseResponse<TraderResponse>>
    {
        public GetTraderByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
