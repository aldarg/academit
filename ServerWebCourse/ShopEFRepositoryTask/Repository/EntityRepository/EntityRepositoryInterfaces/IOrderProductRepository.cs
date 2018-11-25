using System.Collections.Generic;

namespace ShopEFRepositoryTask
{
    internal interface IOrderProductRepository : IRepository<OrderProduct>
    {
        IEnumerable<Product> GetTopSalesProducts();
        Dictionary<Customer, int> GetSalesPerCustomer();
        Dictionary<Category, int> GetSalesPerCategory();
    }
}
