using E_Commerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            Address address = await repository.GetByIdAsync(command.AddressId);
            address.Detail = command.Detail;
            address.District = command.District;
            address.City = command.City;
            address.UserId = command.UserId;
            await repository.UpdateAsync(address);
        }
    }
}
