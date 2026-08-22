using Dapper;
using MicroBasket.Data;
using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Repository.Interfaces;
using System.Data;

namespace MicroBasket.Repository
{
    public class AccountRepository:DapperContext,IAccountRepository
    {
        public AccountRepository(IConfiguration config) : base(config) { }
        public async Task<UserDTO> GetUserByEmail(string email)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "CheckEmail");
                param.Add("@email", email);
                var con = GetConnection();
                return await con.QueryFirstOrDefaultAsync<UserDTO>("ProcLogInSignIn", param, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                return new UserDTO();
            }
        }
        public async Task<int> CreateCustomer(Customer cust)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "SignIn");
                param.Add("@name", cust.UserName);
                param.Add("@phone", cust.UserPhone);
                param.Add("@email", cust.UserEmail);
                param.Add("@add", cust.UserAdd);
                param.Add("@password", cust.Password);
                var con = GetConnection();
                int x=await con.ExecuteAsync("ProcLogInSignIn", param, commandType: CommandType.StoredProcedure);
                return await Task.FromResult(x);
            }
            catch
            {
                return -10;
            }
        }

    }
}
