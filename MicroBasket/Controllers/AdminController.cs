using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroBasket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _admin;
        private readonly IProductService _prod;
        private readonly IOrderService _order;
        public AdminController(IAdminService admin,IProductService prod, IOrderService order)
        {
            _admin = admin;
            _prod = prod;
            _order = order;
        }
        [HttpGet("modify-access/{uid}/{status}")]
        public async Task<IActionResult>GetLoginAccess(int uid,bool status)
        {
            var response= await _admin.ModifyUserStatusAsync(uid, status);

            return response.Success ? Ok(response.Message) : BadRequest(response.Message);
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUserList()
        {
            var userList = await _admin.GetAllUsersAsync();
            return Ok(userList);
        }
        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var report = await _admin.GetReportAsync();
            var recentOrderList =await _order.GetRecentOrderAsync();
            var lowStock = await _prod.LowStockProductsAsync();
            return Ok(new {Report=report,RecentOrders=recentOrderList,LowStock=lowStock});
        }
        

    }
}
