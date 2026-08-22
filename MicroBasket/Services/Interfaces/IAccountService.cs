using MicroBasket.Models;
using MicroBasket.Models.DTOs;

namespace MicroBasket.Services.Interfaces
{
    public interface IAccountService
    {
        Task<(LoginResponseDTO Data, bool Success, string Message)> LoginAsync(LoginRequestDTO data);
        Task<(bool Success, string Message)> SignInAsync(Customer cust);

    }
}
