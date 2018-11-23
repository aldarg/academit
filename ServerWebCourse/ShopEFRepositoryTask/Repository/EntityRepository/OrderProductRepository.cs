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

        public Product[] GetTopSalesProducts()
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

        public dynamic GetSalesPerCustomer()
        {
            var result = _dbSet
                .GroupBy(x => x.Order.Customer)
                .Select(x => new
                    {
                        x.Key.LastName,
                        x.Key.FirstName,
                        Sum = x.Sum(y => y.Quantity * y.Product.Price)
                    })
                .ToArray();

            return result;
        }

        public dynamic GetSalesPerCategory()
        {
            var productsSoldDictionary = _dbSet
                .GroupBy(x => x.Product)
                .Select(x => new
                {
                    x.Key,
                    TotalQuantity = x.Sum(y => y.Quantity)
                })
                .ToDictionary(x => x.Key, x => x.TotalQuantity);

            var categories = _db.Set<Category>();

            var result = new List<dynamic>();
            foreach (var category in categories.Include(c => c.Products))
            {
                var sum = category.Products.Sum(product => productsSoldDictionary[product]);
                var item = new {Category = category, QuantitySold = sum};
                result.Add(item);
            }

            return result;
        }
    }
}
