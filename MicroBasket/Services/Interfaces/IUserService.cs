using MicroBasket.Models;
using MicroBasket.Models.DTOs;

namespace MicroBasket.Services.Interfaces
{
    public interface IUserService
    {
        Task<Customer> GetUserByIdAsync(long id);
        Task<ServiceResponseDTO> UpdateProfileAsync(Customer cust);
        Task<ServiceResponseDTO> ChangePasswordAsync(ChangePasswordDTO dto);
    }
}
