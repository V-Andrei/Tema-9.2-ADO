using DataAcccess.Connection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryBookApp
{
    class SummaryBookApp
    {
        static void Main(string[] args)
        {
            var connection = ConnectionManager.GetConnection();
            //Top10Books(connection);
            //Select2010Books(connection);
            MaxYear(connection);

            Console.ReadKey();
        }
        private static void Top10Books(SqlConnection connection)
        {
            try
            {
                var query = "select * from Book where BookId <= 10";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var currentRow = dataReader;

                    var id = currentRow["BookId"];
                    var title = currentRow["Title"];
                    var price = currentRow["Price"];

                    Console.WriteLine($"{id} - {title} - {price} Lei");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
        private static void MaxYear(SqlConnection connection)
        {
            try
            {
                var query = "select MAX(YEAR) as 'MaxDate' from Book";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var currentRow = dataReader;

                    var maxDate = currentRow["MaxDate"];

                    Console.WriteLine("Max date is: " + maxDate);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
        private static void Select2010Books(SqlConnection connection)
        {
            try
            {
                var query = "select * from Book where Year = 2010";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var currentRow = dataReader;

                    var id = currentRow["BookId"];
                    var title = currentRow["Title"];

                    Console.WriteLine($"{id} - {title}");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
