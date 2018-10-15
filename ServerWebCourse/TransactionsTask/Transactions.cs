using System;
using System.Configuration;
using System.Data.SqlClient;


namespace TransactionsTask
{
    public class Transactions
    {
        public static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection state: " + connection.State);

                // Закомментированная секция с транзакцией и бросанием исключения

                //var transaction = connection.BeginTransaction();

                //try
                //{
                //    var sql = "INSERT INTO Category(Name) VALUES (N'Dry meat')";
                //    using (var command = new SqlCommand(sql, connection))
                //    {
                //        command.Transaction = transaction;
                //        command.ExecuteNonQuery();
                //    }

                //    throw new Exception();

                //    transaction.Commit();
                //}
                //catch (Exception)
                //{
                //    transaction.Rollback();
                //}

                var sql = "INSERT INTO Category(Name) VALUES (N'Dry meat')";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

                throw new Exception();
            }
        }
    }
}
