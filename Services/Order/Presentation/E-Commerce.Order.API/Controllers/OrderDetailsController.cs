using E_Commerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using E_Commerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using E_Commerce.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using E_Commerce.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler;
        private readonly GetOrderDetailQueryHandler getOrderDetailQueryHandler;
        private readonly CreateOrderDetailCommandHandler createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, GetOrderDetailQueryHandler getOrderDetailQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            this.getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            this.getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            this.createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            this.updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            this.removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            List<GetOrderDetailQueryResult> values = await getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            GetOrderDetailByIdQueryResult value = await getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await createOrderDetailCommandHandler.Handle(createOrderDetailCommand);
            return Ok("Sipariş Detayı başarıyla eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            await updateOrderDetailCommandHandler.Handle(updateOrderDetailCommand);
            return Ok("Sipariş Detayı başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            await removeOrderDetailCommandHandler.Handle(removeOrderDetailCommand);
            return Ok("Sipariş Detayı başarıyla silindi.");
        }
    }
}
