using MicroBasket.Models;
using MicroBasket.Models.DTOs;

namespace MicroBasket.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<Customer> GetUserById(long id);
        Task<int> UpdateProfile(Customer cust);
        Task<int> ChangePassword(ChangePasswordDTO dto);

    }
}
