using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetTask
{
    public class AdoNet
    {
        public static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection state: " + connection.State);
                Console.WriteLine();

                var sql = @"
                    SELECT COUNT(*) FROM Product
                ";
                using (var command = new SqlCommand(sql, connection))
                {
                    var productsCount = (int) command.ExecuteScalar();
                    Console.WriteLine($"Количество продуктов в БД: {productsCount}.");
                }
                Console.WriteLine();

                sql = @"
                    INSERT INTO [dbo].[Category]([Name])
                    VALUES (@newCategory)
                ";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@newCategory", "Cheese")
                    {
                        SqlDbType = SqlDbType.NVarChar
                    });

                    command.ExecuteNonQuery();
                }

                int cheeseCategoryId;
                sql = @"
                    SELECT TOP(1) Id
                    FROM Category
                    WHERE Name = N'Cheese'
                ";
                using (var command = new SqlCommand(sql, connection))
                {
                    cheeseCategoryId = (int)command.ExecuteScalar();
                }

                sql = @"
                    INSERT INTO [dbo].[Product]([Name], [CategoryId], [Price])
                    VALUES (@newProductName, @newProductCategory, @newProductPrice)
                ";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@newProductName", "Parmegiano")
                    {
                        SqlDbType = SqlDbType.NVarChar
                    });
                    command.Parameters.Add(new SqlParameter("@newProductCategory", cheeseCategoryId)
                    {
                        SqlDbType = SqlDbType.Int
                    });
                    command.Parameters.Add(new SqlParameter("@newProductPrice", 990)
                    {
                        SqlDbType = SqlDbType.Int
                    });

                    command.ExecuteNonQuery();
                }

                sql = @"
                    UPDATE Product
                    SET Name = @productNewName
                    WHERE Name = @productOldName
                ";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@productOldName", "Parmegiano")
                    {
                        SqlDbType = SqlDbType.NVarChar
                    });
                    command.Parameters.Add(new SqlParameter("@productNewName", "Parmegiano Regiano")
                    {
                        SqlDbType = SqlDbType.NVarChar
                    });

                    command.ExecuteNonQuery();
                }

                sql = @"
                    DELETE FROM Product
                    WHERE Name = @productName
                ";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@productName", "Parmegiano Regiano")
                    {
                        SqlDbType = SqlDbType.NVarChar
                    });

                    command.ExecuteNonQuery();
                }

                sql = @"
                    SELECT
                        p.Name AS N'Продукт',
                        c.Name AS N'Категория',
                        p.Price AS N'Цена'
                    FROM Product AS p
                    INNER JOIN Category AS c
                    ON p.CategoryId = c.Id
                ";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Продукт"]}, {reader["Категория"]}, {reader["Цена"]}");
                        }
                    }
                }
                Console.WriteLine();

                var adapter = new SqlDataAdapter(sql, connection);
                var ds = new DataSet();
                adapter.Fill(ds);

                var dt = ds.Tables[0];
                foreach (DataColumn column in dt.Columns) 
                {
                    Console.Write($"{column.ColumnName, -25}");
                }

                Console.WriteLine();

                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (var cell in cells)
                    {
                        Console.Write($"{cell, -25}");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
