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
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _prod;
        public ProductController(IAdminService admin, IProductService prod)
        {
            _prod = prod;
        }
        [Authorize(Roles ="Admin")]
        [HttpPost("add-new-product")]
        public async Task<IActionResult> PostProduct(ProductDTO prod)
        {
            var response = await _prod.CreateProductAsync(prod);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
        [HttpPut("update-product")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> PutProduct(ProductDTO prod)
        {
            var response = await _prod.UpdateProductAsync(prod);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
        [HttpGet("all-products")]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _prod.GetAllProductsAsync();
            return Ok(response);
        }
        [HttpGet("serach/{keyword}")]
        public async Task<IActionResult> GetSerchResult(string keyword)
        {
            var response = await _prod.SearchProductAsync(keyword);
            return Ok(response);
        }
        [HttpGet("get-product/{pid}")]
        public async Task<IActionResult> GetProduct(long pid)
        {
            var response = await _prod.GetProductByIdAsync(pid);
            return Ok(response);
        }
    }
}
