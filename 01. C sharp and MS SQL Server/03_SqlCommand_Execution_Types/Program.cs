using System;
using System.Data.SqlClient;
using System.Configuration;

namespace _03_SqlCommand_Execution_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Astro"].ConnectionString;

            Console.WriteLine($"Number of Rows:\t{GetNumberOfRows(connStr)}");
            AddRowsInSqlDBTable(connStr);
            Console.WriteLine($"Number of Rows:\t{GetNumberOfRows(connStr)}");
            SelectTheWholeTable(connStr);

            Console.ReadKey();

        }

        // An example of ExecuteNonQuery(), which returns the number of affections
        // this is useful for INSERT, UPDATE, CREATE, DELETE, etc. , i.e. when ro return result is needed
        static void AddRowsInSqlDBTable(string connStr)
        {
            string addNewGalaxy = "INSERT INTO Galaxies (Name) VALUES ('Mrk 263')";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand addRow = new SqlCommand(addNewGalaxy,connection);

                int rowsAffected = addRow.ExecuteNonQuery();
                Console.WriteLine($"The number of affected rows is: {rowsAffected}");
            }
        }

        // An example of ExecuteReader(), which returns the return set of the query
        // Useful for SELECT operations
        static void SelectTheWholeTable(string connStr)
        {
            string selectTable = "SELECT * from Galaxies";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand selTb = new SqlCommand(selectTable, connection);

                using (SqlDataReader reader = selTb.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Console.WriteLine($"{reader.GetValue(0)} \t {reader.GetValue(1)}");
                    }
                }
            }
        }

        // An example of ExecuteScalar(), which returns a scalar value
        // Useful for aggregation functions, such as SUM, COUNT, MIN, MAX, AVG, etc.
        static int GetNumberOfRows(string connStr)
        {
            int num = 0;

            string getRowCount = "SELECT COUNT(*) FROM Galaxies";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand countRows = new SqlCommand(getRowCount, connection);

                num = (int) countRows.ExecuteScalar();
            }

            return num;
        }
    }
}
