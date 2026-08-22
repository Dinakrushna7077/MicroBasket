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
        public AdminController(IAdminService admin)
        {
            _admin = admin;
        }
        [HttpGet("modify-access/{uid}/{status}")]
        public async Task<IActionResult>ModifyLoginAccess(int uid,bool status)
        {
            var response= await _admin.ModifyUserStatusAsync(uid, status);

            return response.Success ? Ok(response.Message) : BadRequest(response.Message);
        }
    }
}
