using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroBasket.Models
{
    public class Orders
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long CustId { get; set; }

        public DateTime DateOfOrder { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(20)]
        public string OrderStatus { get; set; } = string.Empty;
    }
}
