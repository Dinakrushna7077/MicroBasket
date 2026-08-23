using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Repository.Interfaces;
using MicroBasket.Services.Interfaces;

namespace MicroBasket.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _db;
        public ProductService(IProductRepository db)
        {
            _db = db;
        }

        public async Task<ServiceResponseDTO> CreateProductAsync(ProductDTO prod)
        {
            int n = await _db.CreateOrUpdateProduct(prod);
            return n > 0 ?
                new ServiceResponseDTO()
                {
                    Success = true,
                    Message = "Product Created Successfully."
                } :
                new ServiceResponseDTO()
                {
                    Success = false,
                    Message = "Something went wrong please try again later...!"
                };
        }
        public async Task<ServiceResponseDTO> UpdateProductAsync(ProductDTO prod)
        {
            int n = await _db.CreateOrUpdateProduct(prod);
            return n > 0 ?
                new ServiceResponseDTO()
                {
                    Success = true,
                    Message = "Product Updated Successfully."
                } :
                new ServiceResponseDTO()
                {
                    Success = false,
                    Message = "Something went wrong please try again later...!"
                };
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _db.GetAllProducts();
        }
        public async Task<List<Product>> SearchProductAsync(string search)
        {
            return await _db.SearchProduct(search);
        }
        public async Task<Product> GetProductByIdAsync(long pid)
        {
            return await _db.GetProductById(pid);
        }
    }
}
