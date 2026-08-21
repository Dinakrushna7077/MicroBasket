using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroBasket.Models
{
    public class OrderDetails
    {
        [Key]
        public long Id { get; set; }

        public long OrderId { get; set; }

        public long ProdID { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
