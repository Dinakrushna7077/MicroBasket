namespace MicroBasket.Services.Interfaces
{
    public interface IAdminService
    {
        Task<(bool Success, string Message)> ModifyUserStatusAsync(int uid, bool status);
    }
}
