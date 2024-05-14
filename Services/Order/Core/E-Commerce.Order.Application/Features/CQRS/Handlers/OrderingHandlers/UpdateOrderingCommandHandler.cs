using E_Commerce.Order.Application.Features.CQRS.Commands.OrderingCommands;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;
using MediatR;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            Ordering order = await repository.GetByIdAsync(request.OrderingId);
            order.OrderDate = request.OrderDate;
            order.OrderingId = request.OrderingId;
            order.UserId = request.UserId;
            order.TotalPrice = request.TotalPrice;
            await repository.UpdateAsync(order);
        }
    }
}
