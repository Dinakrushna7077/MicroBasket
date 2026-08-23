namespace MicroBasket.Models.DTOs
{
    public class OrderRequestDTO
    {

        public long OrderId { get; set; }
        public long CustId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public long ProdId { get; set; }
        public int Quantity { get; set; }
    }
}
