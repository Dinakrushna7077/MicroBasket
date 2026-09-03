using Dapper;
using MicroBasket.Data;
using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Repository.Interfaces;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MicroBasket.Repository
{
    public class OrderRepository:DapperContext,IOrderRepository
    {
        public OrderRepository(IConfiguration _config) : base(_config) { }
        public async Task<List<OrdersDTO>> OrderList(long id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "OrderedList");
                param.Add("@custId", id);

                var con = GetConnection();
                return (await con.QueryAsync<OrdersDTO>("ProcManageOrders", param,commandType:CommandType.StoredProcedure)).ToList();
            }
            catch
            {
                return new List<OrdersDTO>();
            }
        }
        public async Task<int> UpdateOrderStatus(UpdateOrderDTO data)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action","UpdateOrderStatus");
                param.Add("@orderId", data.Id);
                param.Add("@custId", data.CustId);
                param.Add("@status", data.Status);
                
                var con= GetConnection();
                int x=await con.ExecuteAsync("ProcManageOrders", param,commandType: CommandType.StoredProcedure);
                return await Task.FromResult(x);
            }
            catch
            {
                return -10;
            }
        }
        public async Task<int> PlaceOrder(OrderRequestDTO dto)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "PlaceOrder");
                param.Add("@custId", dto.CustId);
                param.Add("@status", "Pending");
                param.Add("@newOrderId", dbType: DbType.Int64, direction: ParameterDirection.Output);

                var con = GetConnection();
                int x = await con.ExecuteAsync("ProcManageOrders", param, commandType: CommandType.StoredProcedure);
                if(x<0)
                {
                    return await Task.FromResult(x);
                }
                long newOrderId = param.Get<long>("@newOrderId");
                foreach (var prod in dto.CartDTOs)
                {
                    DynamicParameters detailsParam = new DynamicParameters();
                    detailsParam.Add("@action", "OrderDetails");
                    detailsParam.Add("@prodId", prod.ProdId);
                    detailsParam.Add("@quantity", prod.Quantity);
                    detailsParam.Add("@orderId", newOrderId);
                    int y = await con.ExecuteAsync("ProcManageOrders", detailsParam, commandType: CommandType.StoredProcedure);
                }

                return await Task.FromResult(x);
            }
            catch
            {
                return -10;
            }
        }
        public async Task<List<OrderListDTO>> FilterOrderList(string? Status)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "Filter");
                param.Add("@status", Status);

                var con = GetConnection();
                return (await con.QueryAsync<OrderListDTO>("ProcManageOrders", param, commandType: CommandType.StoredProcedure)).ToList();
            }
            catch
            {
                return new List<OrderListDTO>();
            }
        }
        public async Task<List<OrderDetailsDTO>> GetOrderDetails(long oid)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "Details");
                param.Add("@orderId", oid);

                var con = GetConnection();
                return (await con.QueryAsync<OrderDetailsDTO>("ProcManageOrders", param, commandType: CommandType.StoredProcedure)).ToList();
            }
            catch
            {
                return new List<OrderDetailsDTO>();
            }
        }
        public async Task<List<OrderListDTO>> GetRecentOrder()
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "RecentOrders");

                var con = GetConnection();
                return (await con.QueryAsync<OrderListDTO>("ProcManageOrders", param, commandType: CommandType.StoredProcedure)).ToList();
            }
            catch
            {
                return new List<OrderListDTO>();
            }
        }
        
    }
}
