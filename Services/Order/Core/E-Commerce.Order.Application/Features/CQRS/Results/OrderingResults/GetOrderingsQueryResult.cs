namespace E_Commerce.Order.Application.Features.CQRS.Results.OrderingResults
{
    public class GetOrderingsQueryResult
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
