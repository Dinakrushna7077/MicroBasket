using Dapper;
using MicroBasket.Data;
using MicroBasket.Models;
using MicroBasket.Repository.Interfaces;
using System.Data;

namespace MicroBasket.Repository
{
    public class ProductRepository:DapperContext,IProductRepository
    {
        public ProductRepository(IConfiguration _config) : base(_config) { }
        public async Task<int> CreateOrUpdateProduct(Product prod)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                if (prod.Id > 0)
                {
                    param.Add("@action", "Update");
                    param.Add("@updateDT", DateTime.Now);
                }
                else
                {
                    param.Add("@action", "New");
                }
                param.Add("@name", prod.ProductName);
                param.Add("@description", prod.ProductDesc);
                param.Add("@price", prod.ProductPrice);
                param.Add("@quantity", prod.ProductQuantity);
                param.Add("@imageUrl", prod.ProductImage);

                var con = GetConnection();
                int x = await con.ExecuteAsync("ManageProducts", param, commandType: CommandType.StoredProcedure);
                return await Task.FromResult(x);
            }
            catch
            {
                return -10;
            }
        }
    }
}
