using System;
using System.Data.Entity;

namespace ShopEFRepositoryTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new MyDbInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());

            using (var uow = new UnitOfWork.UnitOfWork(new ShopContext()))
            {
                var productRepo = uow.GetRepository<IProductRepository>();
                var orderProductRepo = uow.GetRepository<IOrderProductRepository>();
                var customerRepo = uow.GetRepository<ICustomerRepository>();
                var categoryRepo = uow.GetRepository<ICategoryRepository>();

                var productToChange = productRepo.GetByName("Роял Канин для котиков, 2 кг");
                if (productToChange != null)
                {
                    productToChange.Name = "Роял Канин для котов и кошек, 2 кг";
                }

                productRepo.Create(new Product { Name = "NoName", Price = 1 });
                uow.Save();

                var productToDelete = productRepo.GetByName("NoName");
                productRepo.Delete(productToDelete);
                uow.Save();

                Console.WriteLine("Самые часто покупаемые товары:");
                foreach (var product in orderProductRepo.GetTopSalesProducts())
                {
                    Console.WriteLine(product.Name);
                }

                Console.WriteLine("Сумма заказов покупателей:");
                foreach (var item in orderProductRepo.GetSalesPerCustomer())
                {
                    Console.WriteLine($"{item.Key.FirstName} {item.Key.LastName}: {item.Value} руб.");
                }

                Console.WriteLine("Общее количество проданных продуктов в разбивке по категориям:");
                foreach (var item in orderProductRepo.GetSalesPerCategory())
                {
                    Console.WriteLine($"{item.Key.Name}: {item.Value}");
                }
            }
        }
    }
}
