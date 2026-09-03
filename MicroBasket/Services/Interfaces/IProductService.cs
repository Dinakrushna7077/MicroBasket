using MicroBasket.Models;
using MicroBasket.Models.DTOs;

namespace MicroBasket.Services.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponseDTO> CreateProductAsync(ProductDTO prod);
        Task<ServiceResponseDTO> UpdateProductAsync(ProductDTO prod);
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> SearchProductAsync(string search);
        Task<Product> GetProductByIdAsync(long pid);
        Task<List<LowStockDTO>> LowStockProductsAsync();
    }
}
