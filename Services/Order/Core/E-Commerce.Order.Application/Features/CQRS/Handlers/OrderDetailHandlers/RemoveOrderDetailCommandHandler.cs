using E_Commerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand command)
        {
            OrderDetail orderDetail = await repository.GetByIdAsync(command.Id);
            await repository.DeleteAsync(orderDetail);
        }
    }
}
