using System.Data.Entity;

namespace ShopEFRepositoryTask
{
    public class OrderRepository : BaseEfRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext db) : base(db)
        {
        }
    }
}
