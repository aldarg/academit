﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShopEFTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new ShopContext();

            using (db)
            {
                // наполнение данными
                AddProducts(db);
                AddCustomers(db);

                // редактирование
                var productToChange = db.Products.FirstOrDefault(x => x.Name == "Роял Канин для котиков, 2 кг");
                productToChange.Name = "Роял Канин для котов и кошек, 2 кг";

                //// удаление
                db.Products.Add(new Product { Name = "NoName", Price = 1 });

                var productToDelete = db.Products.FirstOrDefault(x => x.Name == "NoName");
                db.Products.Remove(productToDelete);

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
                                                FIO = x.Key.Fio,
                                                Sum = x.Select(y => y.Quantity * y.Product.Price).Sum()
                                            })
                                            .ToArray();

                Console.WriteLine();

                Console.WriteLine("Сумма заказов покупателей:");
                foreach (var customer in customersWithSum)
                {
                    Console.WriteLine($"{customer.FIO}: {customer.Sum} руб.");
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

        private static void AddProducts(ShopContext db)
        {
            var categoryFood = new Category { Name = "Корма" };
            var categoryLitter = new Category { Name = "Наполнители" };
            var categorySnack = new Category { Name = "Лакомства" };
            var categoryToy = new Category { Name = "Игрушки" };

            db.Categories.AddRange(new List<Category> { categoryFood, categoryToy, categoryLitter, categorySnack });

            var product1 = new Product { Name = "Роял Канин для котиков, 2 кг", Price = 100 };
            product1.Categories.Add(categoryFood);

            var product2 = new Product { Name = "Роял Канин для собак, 15 кг", Price = 500 };
            product2.Categories.Add(categoryFood);

            var product3 = new Product { Name = "Катсан, 5 л", Price = 150 };
            product3.Categories.Add(categoryLitter);

            var product4 = new Product { Name = "Сибирская кошка, 8 л.", Price = 800 };
            product4.Categories.Add(categoryLitter);

            var product5 = new Product { Name = "Рубец говяжий, 2 шт.", Price = 50 };
            product5.Categories.Add(categorySnack);

            var product6 = new Product { Name = "Кошачья мята", Price = 20 };
            product6.Categories.Add(categoryLitter);
            product6.Categories.Add(categoryToy);

            var product7 = new Product { Name = "Грейфер №1", Price = 1000 };
            product7.Categories.Add(categoryToy);

            var product8 = new Product { Name = "Мегаигрушка с кормом внутри", Price = 5000 };
            product8.Categories.Add(categoryToy);
            product8.Categories.Add(categoryFood);

            db.Products.AddRange(new List<Product> { product1, product2, product3, product4, product5, product6, product7, product8 });
            db.SaveChanges();
        }

        private static void AddCustomers(ShopContext db)
        {
            var customer1 = new Customer
            {
                Fio = "Вася",
                Phone = "22222",
                Email = "1@22.ru",
                Orders = new List<Order>
                    {
                        new Order
                        {
                            Date = new DateTime(2018, 10, 20),
                            OrderProducts = new List<OrderProduct>
                            {
                                new OrderProduct
                                {
                                    Product = db.Products.FirstOrDefault(x => x.Name == "Роял Канин для котиков, 2 кг"),
                                    Quantity = 2
                                },
                                new OrderProduct
                                {
                                    Product = db.Products.FirstOrDefault(x => x.Name == "Катсан, 5 л"),
                                    Quantity = 1
                                }
                            }
                        },
                        new Order
                        {
                            Date = new DateTime(2018, 8, 3),
                            OrderProducts = new List<OrderProduct>
                            {
                                new OrderProduct
                                {
                                    Product = db.Products.FirstOrDefault(x => x.Name == "Сибирская кошка, 8 л."),
                                    Quantity = 3
                                },
                                new OrderProduct
                                {
                                    Product = db.Products.FirstOrDefault(x => x.Name == "Кошачья мята"),
                                    Quantity = 10
                                }
                            }
                        }
                    }
            };

            var customer2 = new Customer
            {
                Fio = "Петя",
                Phone = "333",
                Email = "2@22.ru",
                Orders = new List<Order>
                {
                    new Order
                    {
                        Date = new DateTime(2018, 01, 10),
                        OrderProducts = new List<OrderProduct>
                        {
                            new OrderProduct
                            {
                                Product = db.Products.FirstOrDefault(x => x.Name == "Роял Канин для собак, 15 кг"),
                                Quantity = 1
                            },
                            new OrderProduct
                            {
                                Product = db.Products.FirstOrDefault(x => x.Name == "Рубец говяжий, 2 шт."),
                                Quantity = 2
                            }
                        }
                    },
                    new Order
                    {
                        Date = new DateTime(2018, 4, 13),
                        OrderProducts = new List<OrderProduct>
                        {
                            new OrderProduct
                            {
                                Product = db.Products.FirstOrDefault(x => x.Name == "Роял Канин для собак, 15 кг"),
                                Quantity = 2
                            },
                            new OrderProduct
                            {
                                Product = db.Products.FirstOrDefault(x => x.Name == "Грейфер №1"),
                                Quantity = 1
                            }
                        }
                    }
                }
            };

            var customer3 = new Customer
            {
                Fio = "Коля",
                Phone = "11111",
                Email = "3@22.ru",
                Orders = new List<Order>
                {
                    new Order
                    {
                        Date = new DateTime(2018, 9, 10),
                        OrderProducts = new List<OrderProduct>
                        {
                            new OrderProduct
                            {
                                Product = db.Products.FirstOrDefault(x => x.Name == "Мегаигрушка с кормом внутри"),
                                Quantity = 1
                            }
                        }
                    },
                    new Order
                    {
                        Date = new DateTime(2018, 2, 23),
                        OrderProducts = new List<OrderProduct>
                        {
                            new OrderProduct
                            {
                                Product = db.Products.FirstOrDefault(x => x.Name == "Сибирская кошка, 8 л."),
                                Quantity = 3
                            },
                            new OrderProduct
                            {
                                Product = db.Products.FirstOrDefault(x => x.Name == "Роял Канин для котиков, 2 кг"),
                                Quantity = 2
                            },
                            new OrderProduct
                            {
                                Product = db.Products.FirstOrDefault(x => x.Name == "Кошачья мята"),
                                Quantity = 3
                            }
                        }
                    }
                }
            };

            db.Customers.AddRange(new List<Customer> { customer1, customer2, customer3 });
            db.SaveChanges();
        }
    }
}