using MicroBasket.Models;
using MicroBasket.Models.DTOs;

namespace MicroBasket.Services.Interfaces
{
    public interface IAdminService
    {
        Task<ServiceResponseDTO> ModifyUserStatusAsync(int uid, bool status);
        Task<List<Customer>> GetAllUsersAsync();
    }
}
