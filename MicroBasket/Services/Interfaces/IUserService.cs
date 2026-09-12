using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Models.DTOs.Customer;

namespace MicroBasket.Services.Interfaces
{
    public interface IUserService
    {
        Task<Customer> GetUserByIdAsync(long id);
        Task<ServiceResponseDTO> UpdateProfileAsync(ProfileDTO dto);
        Task<ServiceResponseDTO> ChangePasswordAsync(ChangePasswordDTO dto);
    }
}
