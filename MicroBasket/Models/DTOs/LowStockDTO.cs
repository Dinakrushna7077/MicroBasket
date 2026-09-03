namespace MicroBasket.Models.DTOs
{
    public class LowStockDTO
    {
        public long Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int ProductQuantity { get; set; }
    }
}
