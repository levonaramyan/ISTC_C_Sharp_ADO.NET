using System;
using System.Configuration; // for using App.config file for getting connection string
                            // necessary to add into references System.Configuration.dll

namespace _01_Connection_String
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing the connection string
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Astro;Integrated Security=True;";

            // Best Practice: getting the connection string from configuration manager
            string connStr2 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            Console.WriteLine(connStr+"\n"+connStr2); // getting sure that the strings are equal

            Console.ReadKey();
        }
    }
}
