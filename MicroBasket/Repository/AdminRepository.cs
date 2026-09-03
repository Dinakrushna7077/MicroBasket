using Dapper;
using MicroBasket.Data;
using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Repository.Interfaces;
using System.Data;

namespace MicroBasket.Repository
{
    public class AdminRepository:DapperContext,IAdminRepository
    {
        public AdminRepository(IConfiguration config) : base(config) { }
        
        public async Task<int> ModifyUserStatus(int userId, bool status)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "UpdateStatus");
                param.Add("@id", userId);
                param.Add("@status", status);

                var con = GetConnection();
                int x = await con.ExecuteAsync("ProcManageuser", param, commandType: CommandType.StoredProcedure);
                return await Task.FromResult(x);
            }
            catch
            {
                return -10;
            }
        }
        public async Task<List<Customer>> GetAllUsers()
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "SelectAll");
                var con = GetConnection();
                return (await con.QueryAsync<Customer>("ProcManageuser", param, commandType: CommandType.StoredProcedure)).ToList();
            }
            catch
            {
                return new List<Customer>();
            }
        }
        public async Task<ReportDTO> Reports()
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "Reports");

                var con = GetConnection();
                return await con.QueryFirstOrDefaultAsync<ReportDTO>("ProcManageOrders", param, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                return new ReportDTO();
            }
        }
    }
}
