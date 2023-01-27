using Microsoft.Data.Sqlite;
using System;

namespace Sqlite.Core.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var connection = new SqliteConnection("Data Source=app.db"))
            {
                connection.Open();

                connection.Close();
            }

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
