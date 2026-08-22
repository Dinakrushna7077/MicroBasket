namespace MicroBasket.Models.DTOs
{
    public class UserDTO
    {
        public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string Role {  get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

    }
}
