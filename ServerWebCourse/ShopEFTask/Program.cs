using System;
using System.Data.Entity;
using System.Linq;
using ShopEFTask.Migrations;

namespace ShopEFTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Database.SetInitializer(new MyDbInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());

            using (var db = new ShopContext())
            {
                // редактирование
                var productToChange = db.Products.FirstOrDefault(x => x.Name == "Роял Канин для котиков, 2 кг");
                if (productToChange != null)
                {
                    productToChange.Name = "Роял Канин для котов и кошек, 2 кг";
                }
                db.SaveChanges();

                //// удаление
                db.Products.Add(new Product { Name = "NoName", Price = 1 });
                db.SaveChanges();

                var productToDelete = db.Products.FirstOrDefault(x => x.Name == "NoName");
                db.Products.Remove(productToDelete);
                db.SaveChanges();

                // LINQ Запросы
                //var productOrdersCount = db.OrderProducts
                //                            .GroupBy(x => x.ProductId)
                //                            .Max(x => x.Count());
                //var mostPopularProducts = db.OrderProducts
                //                            .GroupBy(x => x.ProductId)
                //                            .Where(x => x.Count() == productOrdersCount)
                //                            .Select(x => x.FirstOrDefault().Product.Name)
                //                            .ToArray();

                var productsSold = db.OrderProducts
                    .GroupBy(x => x.Product)
                    .Select(x => new
                    {
                        x.Key,
                        TotalQuantity = x.Sum(y => y.Quantity)
                    });
                var productsSoldMaxQuantity = productsSold.Max(x => x.TotalQuantity);
                var mostPopularProducts = productsSold
                    .Where(x => x.TotalQuantity == productsSoldMaxQuantity)
                    .Select(x => x.Key)
                    .ToArray();

                Console.WriteLine("Самые часто покупаемые товары:");
                foreach (var item in mostPopularProducts)
                {
                    Console.WriteLine(item.Name);
                }

                var customersWithSum = db.OrderProducts
                                            .GroupBy(x => x.Order.Customer)
                                            .Select(x => new
                                            {
                                                x.Key.LastName,
                                                x.Key.FirstName,
                                                Sum = x.Sum(y => y.Quantity * y.Product.Price)
                                            })
                                            .ToArray();

                Console.WriteLine();

                Console.WriteLine("Сумма заказов покупателей:");
                foreach (var customer in customersWithSum)
                {
                    Console.WriteLine($"{customer.LastName} {customer.FirstName}: {customer.Sum} руб.");
                }

                Console.WriteLine();

                Console.WriteLine("Общее количество проданных продуктов в разбивке по категориям:");

                var productsSoldDictionary = productsSold.ToDictionary(x => x.Key, x => x.TotalQuantity);
                foreach (var category in db.Categories.Include(c => c.Products))
                {
                    Console.Write($"{category.Name}: ");
                    var productsSoldTotal = category.Products.Sum(product => productsSoldDictionary[product]);
                    Console.WriteLine(productsSoldTotal);
                }
            }
        }
    }
}
