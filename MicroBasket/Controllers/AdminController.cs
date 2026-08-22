using MicroBasket.Models;
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
        public AdminController(IAdminService admin,IProductService prod)
        {
            _admin = admin;
            _prod = prod;
        }
        [HttpGet("modify-access/{uid}/{status}")]
        public async Task<IActionResult>ModifyLoginAccess(int uid,bool status)
        {
            var response= await _admin.ModifyUserStatusAsync(uid, status);

            return response.Success ? Ok(response.Message) : BadRequest(response.Message);
        }
        public async Task<IActionResult>AddProduct(Product prod)
        {
            var response=await _prod.CreateProductAsync(prod);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
        public async Task<IActionResult>UpdateProduct(Product prod)
        {
            var response=await _prod.UpdateProductAsync(prod);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
    }
}
