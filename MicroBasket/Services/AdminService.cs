using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Repository.Interfaces;
using MicroBasket.Services.Interfaces;

namespace MicroBasket.Services
{
    public class AdminService:IAdminService
    {
        private readonly IAdminRepository _db;
        public AdminService(IAdminRepository db)
        {
            _db = db;
        }

        public async Task<ServiceResponseDTO> ModifyUserStatusAsync(int uid,bool status)
        {
            int n=await _db.ModifyUserStatus(uid, status);

            return n > 0 ? 
                new ServiceResponseDTO() {
                    Success = true, 
                    Message = "Status Updated" 
                } :
                new ServiceResponseDTO() { 
                    Success = true, 
                    Message = "Something went wrong please try again later...!" 
                };
        }
        public async Task<List<Customer>> GetAllUsersAsync()
        {
            return await _db.GetAllUsers();
        }
        public async Task<ReportDTO> GetReportAsync()
        {
            return await _db.Reports();
        }


    }
}
