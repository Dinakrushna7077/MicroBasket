using Dapper;
using MicroBasket.Data;
using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Repository.Interfaces;
using System.Data;

namespace MicroBasket.Repository
{
    public class ProductRepository:DapperContext,IProductRepository
    {
        public ProductRepository(IConfiguration _config) : base(_config) { }
        public async Task<int> CreateOrUpdateProduct(ProductDTO prod)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                if (prod.Id > 0)
                {
                    param.Add("@action", "Update");
                    param.Add("@id", prod.Id);
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
        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "AllProducts");
                var con= GetConnection();

                return (await con.QueryAsync<Product>("ManageProducts", param, commandType: CommandType.StoredProcedure)).ToList();
            }
            catch
            {
                return new List<Product>();
            }
        }
        public async Task<List<Product>> SearchProduct(string search)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "Search");
                param.Add("@keyword", search);
                var con = GetConnection();

                return (await con.QueryAsync<Product>("ManageProducts", param, commandType: CommandType.StoredProcedure)).ToList();
            }
            catch
            {
                return new List<Product>();
            }
        }
        public async Task<Product> GetProductById(long pid)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "Select");
                param.Add("@id", pid);
                var con = GetConnection();

                return await con.QueryFirstOrDefaultAsync<Product>("ManageProducts", param, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                return new Product();
            }
        }
        public async Task<List<LowStockDTO>> LowStockProducts()
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@action", "LowStock");
                var con = GetConnection();

                return (await con.QueryAsync<LowStockDTO>("ManageProducts", param, commandType: CommandType.StoredProcedure)).ToList();
            }
            catch
            {
                return new List<LowStockDTO>();
            }
        }
    }
}
