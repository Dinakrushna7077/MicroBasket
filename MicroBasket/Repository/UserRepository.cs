using Dapper;
using MicroBasket.Data;
using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Models.DTOs.Customer;
using MicroBasket.Repository.Interfaces;
using System.Data;

namespace MicroBasket.Repository
{
    public class UserRepository:DapperContext,IUserRepository
    {
        public UserRepository(IConfiguration _config) : base(_config) { }
        public async Task<Customer> GetUserById(long id)
        {
            try
            {
                DynamicParameters param=new DynamicParameters();
                param.Add("@action", "SelectOne");
                param.Add("@id", id);

                var con = GetConnection();
                return await con.QueryFirstOrDefaultAsync<Customer>("ProcManageuser", param, commandType: CommandType.StoredProcedure);
            }
            catch {
                return new Customer();
            }
        }
        public async Task<int> UpdateProfile(ProfileDTO dto)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "UpdateProfile");
                param.Add("@id", dto.Id);
                param.Add("@name", dto.UserName);
                param.Add("@phone", dto.UserPhone);
                param.Add("@email", dto.UserEmail);
                param.Add("@add", dto.UserAdd);
                var con = GetConnection();
                int x = await con.ExecuteAsync("ProcManageuser", param, commandType: CommandType.StoredProcedure);
                return await Task.FromResult(x);
            }
            catch { 
                return -10;
            }
        }
        public async Task<int> ChangePassword(ChangePasswordDTO dto)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "ChangePass");
                param.Add("@password", dto.NewPassword);
                param.Add("@id", dto.Id);
                var con = GetConnection();
                int x = await con.ExecuteAsync("ProcManageuser", param, commandType: CommandType.StoredProcedure);
                return await Task.FromResult(x);
            }
            catch {
                return -10;
            }
        }
    }
}
