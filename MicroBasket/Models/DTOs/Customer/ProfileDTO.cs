using System.ComponentModel.DataAnnotations;

namespace MicroBasket.Models.DTOs.Customer
{
    public class ProfileDTO
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string UserAdd { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        [Phone]
        public string UserPhone { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string UserEmail { get; set; } = string.Empty;
    }
}
