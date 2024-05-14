using E_Commerce.Order.Application.Features.CQRS.Results.OrderDetailResults;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            List<OrderDetail> orderDetails = await repository.GetAllAsync();
            return orderDetails.Select(x => new GetOrderDetailQueryResult
            {
                OrderDetailId = x.OrderDetailId,
                OrderingId = x.OrderingId,
                ProductAmount = x.ProductAmount,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice,
            }).ToList();
        }
    }
}
