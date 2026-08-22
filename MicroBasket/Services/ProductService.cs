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

        public async Task<ServiceResponseDTO> CreateProductAsync(Product prod)
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
                    Success = true,
                    Message = "Something went wrong please try again later...!"
                };
        }
        public async Task<ServiceResponseDTO> UpdateProductAsync(Product prod)
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
                    Success = true,
                    Message = "Something went wrong please try again later...!"
                };
        }
    }
}
