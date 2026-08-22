using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Repository.Interfaces;
using MicroBasket.Services.Interfaces;

namespace MicroBasket.Services
{
    public class AccountService:IAccountService
    {
        private readonly IAccountRepository _repo;
        public AccountService(IAccountRepository repo)
        {
            _repo = repo;
        }

        public async Task<(LoginResponseDTO Data, bool Success,string Message)> LoginAsync(LoginRequestDTO data)
        {
            LoginResponseDTO response = new LoginResponseDTO();
            var user=await _repo.GetUserByEmail(data.Email);
            if(user==null)
            {
                return (response,false,"Invalid Email Id");
            }
            if(!user.IsActive)
            {
                return (response, false, "Inactive Account ! Contact To Admin.");
            }
            var isValidPass = BCrypt.Net.BCrypt.Verify(data.Password, user.UserPassword);
            if(!isValidPass)
            {
                return (response, false, "Invalid Password...");
            }
            return (new LoginResponseDTO()
            {
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                UserId = user.UserId,
                Role = user.Role
            }, 
            true, 
            "");
        }
        public async Task<(bool Success,string Message)> SignInAsync(Customer cust)
        {
            var user = await _repo.GetUserByEmail(cust.UserEmail);
            if(user!=null)
            {
                return (false, "Email id already registered ! please login...");
            }
            int n=await _repo.CreateCustomer(cust);
            if(n<=0)
            {
                return (false,"Unable to Registered ! Please try again after some time...");
            }
            return (true,"User Registered Successfully");
        }
    }
}
