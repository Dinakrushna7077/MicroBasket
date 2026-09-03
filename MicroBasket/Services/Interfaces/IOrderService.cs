using MicroBasket.Models;
using MicroBasket.Models.DTOs;

namespace MicroBasket.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ServiceResponseDTO> PlaceOrderAsync(OrderRequestDTO dto);
        Task<List<OrdersDTO>> OrderListAsync(long id);
        Task<List<OrderListDTO>> FilterOrderListAsync(string status);
        Task<ServiceResponseDTO> UpdateOrderStatusAsync(UpdateOrderDTO data);
        Task<List<OrderDetailsDTO>> GetOrderDetailsAsync(long oid);
        Task<List<OrderListDTO>> GetRecentOrderAsync();
    }
}
