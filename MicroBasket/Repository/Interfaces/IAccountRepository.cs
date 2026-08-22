using MicroBasket.Models;
using MicroBasket.Models.DTOs;

namespace MicroBasket.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<UserDTO> GetUserByEmail(string email);
        Task<int> CreateCustomer(Customer cust);
    }
}
