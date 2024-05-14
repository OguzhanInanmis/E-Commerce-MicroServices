using E_Commerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using E_Commerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using E_Commerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using E_Commerce.Order.Application.Features.CQRS.Results.AddressResults;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressesQueryHandler getAddressesQueryHandler;
        private readonly GetAddressByIdQueryHandler getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler removeAddressCommandHandler;

        public AddressesController(GetAddressesQueryHandler getAddressesQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            this.getAddressesQueryHandler = getAddressesQueryHandler;
            this.getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            this.createAddressCommandHandler = createAddressCommandHandler;
            this.updateAddressCommandHandler = updateAddressCommandHandler;
            this.removeAddressCommandHandler = removeAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            List<GetAddressQueryResult> values = await getAddressesQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            GetAddressByIdQueryResult value = await getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
        {
            await createAddressCommandHandler.Handle(createAddressCommand);
            return Ok("Adres başarıyla eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
        {
            await updateAddressCommandHandler.Handle(updateAddressCommand);
            return Ok("Adres başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(RemoveAddressCommand removeAddressCommand)
        {
            await removeAddressCommandHandler.Handle(removeAddressCommand);
            return Ok("Adres başarıyla silindi.");
        }
    }
}
