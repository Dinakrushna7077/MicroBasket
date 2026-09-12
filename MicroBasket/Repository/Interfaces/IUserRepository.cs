using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Models.DTOs.Customer;

namespace MicroBasket.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<Customer> GetUserById(long id);
        Task<int> UpdateProfile(ProfileDTO dto);
        Task<int> ChangePassword(ChangePasswordDTO dto);

    }
}
