using MicroBasket.Models;

namespace MicroBasket.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<int> CreateOrUpdateProduct(Product prod);
    }
}
