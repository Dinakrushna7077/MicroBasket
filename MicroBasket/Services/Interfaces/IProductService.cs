using MicroBasket.Models;
using MicroBasket.Models.DTOs;

namespace MicroBasket.Services.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponseDTO> CreateProductAsync(Product prod);
        Task<ServiceResponseDTO> UpdateProductAsync(Product prod);
    }
}
