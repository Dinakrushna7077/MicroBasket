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
        public AdminController(IAdminService admin,IProductService prod)
        {
            _admin = admin;
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
        

    }
}
