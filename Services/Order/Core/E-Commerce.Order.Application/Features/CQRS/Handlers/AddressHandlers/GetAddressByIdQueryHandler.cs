using E_Commerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using E_Commerce.Order.Application.Features.CQRS.Results.AddressResults;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            Address addresses = await repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = addresses.AddressId,
                City = addresses.City,
                Detail = addresses.Detail,
                District = addresses.District,
                UserId = addresses.UserId
            };
        }
    }
}
