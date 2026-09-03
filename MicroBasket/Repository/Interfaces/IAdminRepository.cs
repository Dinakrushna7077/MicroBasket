using MicroBasket.Models;
using MicroBasket.Models.DTOs;

namespace MicroBasket.Repository.Interfaces
{
    public interface IAdminRepository
    {
        Task<int> ModifyUserStatus(int userId, bool status);
        Task<List<Customer>> GetAllUsers();
        Task<ReportDTO> Reports();
    }
}
