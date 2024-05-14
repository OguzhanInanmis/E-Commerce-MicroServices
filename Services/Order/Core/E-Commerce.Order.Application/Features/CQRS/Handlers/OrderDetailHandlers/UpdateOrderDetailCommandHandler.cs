using E_Commerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            OrderDetail orderDetail = await repository.GetByIdAsync(command.OrderDetailId);
            orderDetail.OrderDetailId = command.OrderDetailId;
            orderDetail.OrderingId = command.OrderingId;
            orderDetail.ProductAmount = command.ProductAmount;
            orderDetail.ProductId = command.ProductId;
            orderDetail.ProductName = command.ProductName;
            orderDetail.ProductPrice = command.ProductPrice;
            orderDetail.ProductTotalPrice = command.ProductTotalPrice;
            await repository.UpdateAsync(orderDetail);

            
        }
    }
}
