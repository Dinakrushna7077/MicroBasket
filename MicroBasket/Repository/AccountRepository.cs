using MicroBasket.Data;
using MicroBasket.Repository.Interfaces;

namespace MicroBasket.Repository
{
    public class AccountRepository:DapperContext,IAccountRepository
    {
        public AccountRepository(IConfiguration config) : base(config) { }
        
    }
}
