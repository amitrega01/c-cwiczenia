using System;
using System.Data.SqlClient;
using Dapper;

namespace TestBazy
{
    class Customer
    {
        public String CustomerID { get; set; }
        public String CompanyName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            string SqlUsername = "protected";
            string SqlPassword = "protected";
            Console.WriteLine("Hello World!");

            var connection = new SqlConnection(
                $"Server=tcp:insudev.database.windows.net,1433;Initial Catalog=NorthwindDB;Persist Security Info=False;User ID={SqlUsername};Password={SqlPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var result = connection.Query<Customer>("select * from Customers");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.CustomerID} | {item.CompanyName}");
            }
        }
    }
}