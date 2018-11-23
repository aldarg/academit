using System.Data.Entity;

namespace ShopEFRepositoryTask
{
    public class CustomerRepository : BaseEfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext db) : base(db)
        {
        }
    }
}
