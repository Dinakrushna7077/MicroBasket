using Microsoft.Data.SqlClient;

namespace MicroBasket.Data
{
    public class DapperContext
    {
        private readonly IConfiguration config;
        public DapperContext(IConfiguration _config)
        {
            config= _config;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(config.GetConnectionString("MicroBasketConnection"));
        }
    }
}
