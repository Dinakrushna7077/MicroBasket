namespace MicroBasket.Models.DTOs
{
    public class OrderRequestDTO
    {

        public long CustId { get; set; }
        public List<MyCartDTO> CartDTOs { get; set; } = new();

    }
}
