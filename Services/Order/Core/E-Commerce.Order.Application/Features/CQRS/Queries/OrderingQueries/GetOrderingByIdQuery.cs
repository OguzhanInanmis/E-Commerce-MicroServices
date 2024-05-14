using E_Commerce.Order.Application.Features.CQRS.Results.OrderingResults;
using MediatR;

namespace E_Commerce.Order.Application.Features.CQRS.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
