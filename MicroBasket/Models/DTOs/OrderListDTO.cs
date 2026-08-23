namespace MicroBasket.Models.DTOs
{
    public class OrderListDTO
    {
        public long OrderId { get; set; }
        public long ProdID { get; set; }
        public long CustId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string CustName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
    }
}
