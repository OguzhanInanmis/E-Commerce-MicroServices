using E_Commerce.Order.Application.Features.CQRS.Commands.OrderingCommands;
using E_Commerce.Order.Application.Features.CQRS.Queries.OrderingQueries;
using E_Commerce.Order.Application.Features.CQRS.Results.OrderingResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderingsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            List<GetOrderingsQueryResult> values = await mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var value = await mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderingCommand command)
        {
            await mediator.Send(command);
            return Ok("Sipariş başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderingCommand command)
        {
            await mediator.Send(command);
            return Ok("Sipariş başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş başarıyla silindi.");
        }
    }
}
