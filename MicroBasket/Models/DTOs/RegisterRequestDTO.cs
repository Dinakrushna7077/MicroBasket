using System.ComponentModel.DataAnnotations;

namespace MicroBasket.Models.DTOs
{
    public class RegisterRequestDTO
    {
        public string UserName { get; set; } = string.Empty;

        public string UserAdd { get; set; } = string.Empty;

        public string UserPhone { get; set; } = string.Empty;

        public string UserEmail { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

    }
}
