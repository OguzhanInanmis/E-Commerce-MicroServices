using MediatR;

namespace E_Commerce.Order.Application.Features.CQRS.Commands.OrderingCommands
{
    public class UpdateOrderingCommand : IRequest
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
