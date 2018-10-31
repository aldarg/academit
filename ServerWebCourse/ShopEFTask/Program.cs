using System;
using System.Data.Entity;
using System.Linq;

namespace ShopEFTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new MyDbInitializer());

            using (var db = new ShopContext())
            {
                // редактирование
                var productToChange = db.Products.FirstOrDefault(x => x.Name == "Роял Канин для котиков, 2 кг");
                productToChange.Name = "Роял Канин для котов и кошек, 2 кг";
                db.SaveChanges();

                //// удаление
                db.Products.Add(new Product { Name = "NoName", Price = 1 });
                db.SaveChanges();

                var productToDelete = db.Products.FirstOrDefault(x => x.Name == "NoName");
                db.Products.Remove(productToDelete);
                db.SaveChanges();

                // LINQ Запросы
                var productOrdersCount = db.OrderProducts
                                            .GroupBy(x => x.ProductId)
                                            .Select(x => x.Count())
                                            .Max();
                var mostPopularProducts = db.OrderProducts
                                            .GroupBy(x => x.ProductId)
                                            .Where(x => x.Count() == productOrdersCount)
                                            .Select(x => x.FirstOrDefault().Product.Name)
                                            .ToArray();

                Console.WriteLine("Самые часто покупаемые товары:");
                foreach (var item in mostPopularProducts)
                {
                    Console.WriteLine(item);
                }

                var customersWithSum = db.OrderProducts
                                            .GroupBy(x => x.Order.Customer)
                                            .Select(x => new
                                            {
                                                LastName = x.Key.LastName,
                                                FirstName = x.Key.FirstName,
                                                Sum = x.Select(y => y.Quantity * y.Product.Price).Sum()
                                            })
                                            .ToArray();

                Console.WriteLine();

                Console.WriteLine("Сумма заказов покупателей:");
                foreach (var customer in customersWithSum)
                {
                    Console.WriteLine($"{customer.LastName} {customer.FirstName}: {customer.Sum} руб.");
                }

                var productsSold = db.OrderProducts
                                        .GroupBy(x => x.Product)
                                        .Select(x => new
                                        {
                                            x.Key,
                                            TotalQuantity = x.Select(y => y.Quantity).Sum()
                                        })
                                        .ToArray();

                Console.WriteLine();

                Console.WriteLine("Общее количество проданных продуктов в разбивке по категориям:");
                foreach (var category in db.Categories.Include(c => c.Products))
                {
                    Console.Write($"{category.Name}: ");
                    var productsSoldTotal = category.Products.Sum(product => productsSold.FirstOrDefault(p => p.Key == product).TotalQuantity);
                    Console.WriteLine(productsSoldTotal);
                }
            }
        }
    }
}
