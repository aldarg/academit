namespace ShopEFRepositoryTask
{
    internal interface IOrderProductRepository : IRepository<OrderProduct>
    {
        Product[] GetTopSalesProducts();
        dynamic GetSalesPerCustomer();
        dynamic GetSalesPerCategory();
    }
}
