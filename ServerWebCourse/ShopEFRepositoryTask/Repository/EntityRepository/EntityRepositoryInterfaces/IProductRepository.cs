namespace ShopEFRepositoryTask
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByName(string name);
    }
}
