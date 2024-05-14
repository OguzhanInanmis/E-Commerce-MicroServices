using E_Commerce.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using E_Commerce.Order.Application.Features.CQRS.Results.OrderDetailResults;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            OrderDetail orderDetail = await repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = orderDetail.OrderDetailId,
                OrderingId = orderDetail.OrderingId,
                ProductAmount = orderDetail.ProductAmount,
                ProductId = orderDetail.ProductId,
                ProductName = orderDetail.ProductName,
                ProductPrice = orderDetail.ProductPrice,
                ProductTotalPrice = orderDetail.ProductTotalPrice
            };
        }
    }
}
