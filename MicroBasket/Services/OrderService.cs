using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Repository.Interfaces;
using MicroBasket.Services.Interfaces;

namespace MicroBasket.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _order;
        public OrderService(IOrderRepository order)
        {
            _order = order;
        }
        public async Task<List<OrdersDTO>> OrderListAsync(long id)
        {
            return await _order.OrderList(id);
        }
        public async Task<ServiceResponseDTO> UpdateOrderStatusAsync(UpdateOrderDTO data)
        {
            int n = await _order.UpdateOrderStatus(data);
            return n > 0 ?
                new ServiceResponseDTO()
                {
                    Success = true,
                    Message = "Order Status Updated."
                } :
                new ServiceResponseDTO()
                {
                    Success = false,
                    Message = "Something went wrong please try again later...!"
                };
        }
        public async Task<ServiceResponseDTO> PlaceOrderAsync(OrderRequestDTO dto)
        {
            int n= await _order.PlaceOrder(dto);
            return n > 0 ?
                new ServiceResponseDTO()
                {
                    Success = true,
                    Message = "Order Placed Successfully."
                } :
                new ServiceResponseDTO()
                {
                    Success = false,
                    Message = "Something went wrong please try again later...!"
                };
        }
        public async Task<List<OrderListDTO>> FilterOrderListAsync(string status)
        {
            return await _order.FilterOrderList(status);
        }
        public async Task<OrderDetailsDTO> GetOrderDetailsAsync(long oid)
        {
            return await _order.GetOrderDetails(oid);
        }
    }
}
