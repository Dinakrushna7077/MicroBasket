using System.ComponentModel.DataAnnotations;

namespace MicroBasket.Models.DTOs
{
    public class MyCartDTO
    {
        [Required]
        public long ProdId { get; set; }
        public int Quantity { get; set; }
    }
}
