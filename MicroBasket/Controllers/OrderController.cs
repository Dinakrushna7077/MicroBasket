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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet("all-orders/{uid}")]
        [Authorize(Roles ="User")]
        public async Task<IActionResult>GetOrders(long uid)
        {
            var orders = await _service.OrderListAsync(uid);
            return Ok(orders);
        }
        [HttpGet("filter-orders/{status}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult>GetOrders(string status)
        {
            var orders = await _service.FilterOrderListAsync(status);
            return Ok(orders);
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("update-order-status")]
        public async Task<IActionResult>PutOrderStatus(UpdateOrderDTO data)
        {
            var response=await _service.UpdateOrderStatusAsync(data);
            return !response.Success?BadRequest(response.Message): Ok(response.Message);
        }
        [HttpPost("place-order")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult>PostOrder(OrderRequestDTO dto)
        {
            var response=await _service.PlaceOrderAsync(dto);
            return !response.Success?BadRequest(response.Message): Ok(response.Message);
        }
        [HttpGet("order-details/{oid}")]
        public async Task<IActionResult>GetOrderDetails(long oid)
        {
            var response=await _service.GetOrderDetailsAsync(oid);
            return response != null ? Ok(response) : BadRequest("Order Not Found");
        }

    }
}
