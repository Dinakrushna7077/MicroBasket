using MicroBasket.Models;

namespace MicroBasket.Repository.Interfaces
{
    public interface IAdminRepository
    {
        Task<int> ModifyUserStatus(int userId, bool status);

    }
}
