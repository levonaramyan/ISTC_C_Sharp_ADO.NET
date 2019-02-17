using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace _02_Creating_Connection
{
    class Program
    {
        static void Main(string[] args)
        {
            // getting connStr from App.config file
            string connStr = ConfigurationManager.ConnectionStrings["Astro"].ConnectionString;

            CreateConnection(connStr);

            CreateConnectionAsync(connStr).Wait();

            Console.ReadKey();
        }

        // creating and opening the connection synchronously
        static void CreateConnection(string connStr)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connStr;
                connection.Open();

                Console.WriteLine("The connection is open");
            }

            Console.WriteLine("The connection is closed");
        }

        // creating and opening the connection asynchronously
        static async Task CreateConnectionAsync(string connStr)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connStr;
                await connection.OpenAsync();

                Console.WriteLine("The async connection is open");
            }

            Console.WriteLine("The async connection is closed");
        }
    }
}
