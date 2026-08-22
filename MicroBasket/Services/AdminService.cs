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

        public async Task<(bool Success,string Message)>ModifyUserStatusAsync(int uid,bool status)
        {
            int n=await _db.ModifyUserStatus(uid, status);
            return n > 0 ? (true, "Status Updated") : (false, "Something went wrong please try again later...!");
        }
    }
}
