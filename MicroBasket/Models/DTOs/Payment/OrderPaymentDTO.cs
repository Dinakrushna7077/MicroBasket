namespace MicroBasket.Models.DTOs.Payment
{
    public class OrderPaymentDTO
    {
        public decimal Amount { get; set; }
        public long OrderId { get; set; } = 0;
    }
}
