namespace MicroBasket.Models.DTOs
{
    public class ReportDTO
    {
        public decimal TotalRevenue { get; set; }
        public long TotalCustomer { get; set; }
        public long TotalProducts { get; set; }
        public long TotalOrders { get; set; }
        public long LowStock { get; set; }
    }
}
