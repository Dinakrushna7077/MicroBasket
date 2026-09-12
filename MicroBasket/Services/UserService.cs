using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Models.DTOs.Customer;
using MicroBasket.Repository.Interfaces;
using MicroBasket.Services.Interfaces;

namespace MicroBasket.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<Customer> GetUserByIdAsync(long id)
        {
            return await _repo.GetUserById(id);
        }
        public async Task<ServiceResponseDTO> UpdateProfileAsync(ProfileDTO dto)
        {
            int n=await _repo.UpdateProfile(dto);
            return n > 0 ?
               new ServiceResponseDTO()
               {
                   Success = true,
                   Message = "Profile Updated Successfully."
               } :
               new ServiceResponseDTO()
               {
                   Success = false,
                   Message = "Something went wrong please try again later...!"
               };
        }
        public async Task<ServiceResponseDTO> ChangePasswordAsync(ChangePasswordDTO dto)
        {
            ServiceResponseDTO response = new ServiceResponseDTO();
            if(dto.NewPassword!=dto.ConfirmPassword)
            {
                response.Success = false;
                response.Message = "New Password and Confirm password not matched";
                return response;
            }

            var user =await _repo.GetUserById(dto.Id);
            var isValidPass = BCrypt.Net.BCrypt.Verify(dto.OldPassword, user.Password);
            if(!isValidPass)
            {
                response.Success=false;
                response.Message = "Ivalid Old Password";
                return response;
            }
            dto.NewPassword = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            int n= await _repo.ChangePassword(dto);
            return n > 0 ?
               new ServiceResponseDTO()
               {
                   Success = true,
                   Message = "Password Changed Successfully."
               } :
               new ServiceResponseDTO()
               {
                   Success = false,
                   Message = "Something went wrong please try again later...!"
               };
        }
    }
}
