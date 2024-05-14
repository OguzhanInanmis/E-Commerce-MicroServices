using E_Commerce.Order.Application.Features.CQRS.Queries.OrderingQueries;
using E_Commerce.Order.Application.Features.CQRS.Results.OrderingResults;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;
using MediatR;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            this.repository = repository;
        }
        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            Ordering order = await repository.GetByIdAsync(request.Id);
            return new()
            {
                OrderDate = order.OrderDate,
                OrderingId = order.OrderingId,
                TotalPrice = order.TotalPrice,
                UserId = order.UserId,
            };
        }
    }
}
