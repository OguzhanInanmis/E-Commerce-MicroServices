using E_Commerce.Order.Application.Features.CQRS.Results.AddressResults;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressesQueryHandler
    {
        private readonly IRepository<Address> repository;

        public GetAddressesQueryHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            List<Address> addresses = await repository.GetAllAsync();
            return addresses.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId
            }).ToList();
        }
    }
}
