using E_Commerce.Order.Application.Features.CQRS.Queries.OrderingQueries;
using E_Commerce.Order.Application.Features.CQRS.Results.OrderingResults;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;
using MediatR;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.OrderingHandlers
{
    public class GetOrderingsQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingsQueryResult>>
    {
        private readonly IRepository<Ordering> repository;

        public GetOrderingsQueryHandler(IRepository<Ordering> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetOrderingsQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            List<Ordering> orderings = await repository.GetAllAsync();
            return orderings.Select(x => new GetOrderingsQueryResult
            {
                OrderDate = x.OrderDate,
                OrderingId = x.OrderingId,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId,
            }).ToList();
        }
    }
}
