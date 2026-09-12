using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Models.DTOs.Customer;
using MicroBasket.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroBasket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _db;
        public UserController(IUserService db)
        {
            _db = db;
        }
        [HttpGet("profile/{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var user=await _db.GetUserByIdAsync(id);
            if(user==null)
                return NotFound();
            return Ok(user);
        }
        [HttpPut("update-profile")]
        public async Task<IActionResult> PutProfile(ProfileDTO dto)
        {
            var response=await _db.UpdateProfileAsync(dto);
            return !response.Success ? BadRequest(response.Message) : Ok(response);
        }
        [HttpPatch("change-password")]
        public async Task<IActionResult> PatchPassword(ChangePasswordDTO dto)
        {
            var response = await _db.ChangePasswordAsync(dto);
            return !response.Success ? BadRequest(response.Message) : Ok(response.Message);
        }
    }
}
