namespace MicroBasket.Models.DTOs
{
    public class UpdateOrderDTO
    {
        public long Id { get; set; }
        public long CustId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
