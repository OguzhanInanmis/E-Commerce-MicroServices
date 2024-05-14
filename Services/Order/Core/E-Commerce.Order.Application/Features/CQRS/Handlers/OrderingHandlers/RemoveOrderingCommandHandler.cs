using E_Commerce.Order.Application.Features.CQRS.Commands.OrderingCommands;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;
using MediatR;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.OrderingHandlers
{
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
    {
        private readonly IRepository<Ordering> repository;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            Ordering order = await repository.GetByIdAsync(request.Id);
            await repository.DeleteAsync(order);
        }
    }
}
