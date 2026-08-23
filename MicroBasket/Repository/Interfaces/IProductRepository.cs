using MicroBasket.Models;
using MicroBasket.Models.DTOs;

namespace MicroBasket.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<int> CreateOrUpdateProduct(ProductDTO prod);
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> SearchProduct(string search);
        Task<Product> GetProductById(long pid);
    }
}
