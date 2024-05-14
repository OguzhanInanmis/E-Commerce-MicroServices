using E_Commerce.Order.Application.Features.CQRS.Results.OrderingResults;
using MediatR;

namespace E_Commerce.Order.Application.Features.CQRS.Queries.OrderingQueries
{
    public class GetOrderingQuery : IRequest<List<GetOrderingsQueryResult>>
    {
      
    }
}
