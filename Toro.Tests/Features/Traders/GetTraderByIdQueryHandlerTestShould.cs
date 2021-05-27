using Moq;
using System.Threading;
using System.Threading.Tasks;
using Toro.Application.Features.Traders;
using Toro.Application.Interfaces;
using Toro.Domain.Entities;
using Xunit;

namespace Toro.Tests.Features.Traders
{
    public class GetTraderByIdQueryHandlerTestShould
    {
        [Fact]
        public async Task Handle_GetTraderByIdQuery_WithSuccess()
        {
            var repository = new Mock<ITraderRepository>();

            var request = new GetTraderByIdQuery(1);
            var query = new GetTraderByIdQueryHandler(repository.Object);
            var response = new Trader() { Name = "joão" };

            repository.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(() => response);

            var result = await query.Handle(request, new CancellationToken());

            Assert.Equal(response.Name, result.Data.Name); ;
        }

        [Fact]
        public async Task Handle_GetTraderByIdQuery_WithError_AndReturn()
        {
            var repository = new Mock<ITraderRepository>();

            var request = new GetTraderByIdQuery(1);
            var query = new GetTraderByIdQueryHandler(repository.Object);

            repository.Invocations.Clear();
            repository.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(() => null);

            var result = await query.Handle(request, new CancellationToken());

            Assert.Null(result); ;
        }
    }
}
