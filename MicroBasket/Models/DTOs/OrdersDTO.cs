namespace MicroBasket.Models.DTOs
{
    public class OrdersDTO
    {
        public long OrderId { get; set; }
        public long ProdID { get; set; }
        /*public int Quantity { get; set; }
        public decimal Price { get; set; }*/
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
    }
}
