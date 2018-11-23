using System.Data.Entity;
using System.Linq;

namespace ShopEFRepositoryTask
{
    public class ProductRepository : BaseEfRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext db) : base(db)
        {
        }

        public Product GetByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }
    }
}
