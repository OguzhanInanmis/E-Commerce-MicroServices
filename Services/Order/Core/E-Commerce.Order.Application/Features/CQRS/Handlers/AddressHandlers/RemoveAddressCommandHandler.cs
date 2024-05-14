using E_Commerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> repository;

        public RemoveAddressCommandHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveAddressCommand command)
        {
            Address address = await repository.GetByIdAsync(command.Id);
            await repository.DeleteAsync(address);
        }
    }
}
