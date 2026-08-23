using MicroBasket.Models;
using MicroBasket.Models.DTOs;

namespace MicroBasket.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> PlaceOrder(OrderRequestDTO dto);
        Task<List<OrdersDTO>> OrderList(long id);
        Task<int> UpdateOrderStatus(UpdateOrderDTO status);
        Task<List<OrderListDTO>> FilterOrderList(string Status);
        Task<OrderDetailsDTO> GetOrderDetails(long oid);

    }
}
