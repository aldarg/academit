using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShopEFRepositoryTask
{
    public class OrderProductRepository : BaseEfRepository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(DbContext db) : base(db)
        {
        }

        public IEnumerable<Product> GetTopSalesProducts()
        {
            var productsSold = _dbSet
                .GroupBy(x => x.Product)
                .Select(x => new
                {
                    x.Key,
                    TotalQuantity = x.Sum(y => y.Quantity)
                });

            var productsSoldMaxQuantity = productsSold.Max(x => x.TotalQuantity);

            var result = productsSold
                .Where(x => x.TotalQuantity == productsSoldMaxQuantity)
                .Select(x => x.Key)
                .ToArray();

            return result;
        }

        public Dictionary<Customer, int> GetSalesPerCustomer()
        {
            var result = _dbSet
                .GroupBy(x => x.Order.Customer)
                .Select(x => new
                    {
                        Customer = x.Key,
                        Sum = x.Sum(y => y.Quantity * y.Product.Price)
                    })
                .ToDictionary(x => x.Customer, x => x.Sum);

            return result;
        }

        public Dictionary<Product, int> GetProductSalesQuantitive()
        {
            var result = _dbSet
                .GroupBy(x => x.Product)
                .Select(x => new
                {
                    x.Key,
                    TotalQuantity = x.Sum(y => y.Quantity)
                })
                .ToDictionary(x => x.Key, x => x.TotalQuantity);

            return result;
        }

        public Dictionary<Category, int> GetSalesPerCategory()
        {
            var categories = _db.Set<Category>();
            var sales = GetProductSalesQuantitive();

            var result = new Dictionary<Category, int>();
            foreach (var category in categories.Include(c => c.Products))
            {
                var sum = category.Products.Sum(product => sales[product]);
                result.Add(category, sum);
            }

            return result;
        }
    }
}
