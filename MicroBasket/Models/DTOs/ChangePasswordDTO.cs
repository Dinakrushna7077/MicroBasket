namespace MicroBasket.Models.DTOs
{
    public class ChangePasswordDTO
    {
        public long Id { get; set; }
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
