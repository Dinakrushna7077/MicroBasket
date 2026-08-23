using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroBasket.Models.DTOs
{
    public class ProductDTO
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDesc { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, double.MaxValue)]
        public decimal ProductPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ProductQuantity { get; set; }

        [Required]
        public string ProductImage { get; set; } = string.Empty;
    }
}
