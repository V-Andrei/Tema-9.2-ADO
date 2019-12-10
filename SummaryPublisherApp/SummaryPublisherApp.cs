using DataAcccess.Connection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryPublisherApp
{
    class SummaryBookApp
    {
        static void Main(string[] args)
        {
            //var connection = ConnectionManager.GetConnection();
            string connectionString = "Data Source=.;Initial Catalog=HomeworkWeek9Day1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //NumberRow(connection);
            //Top10Publishers(connection);
            NumberBooksForPublisher(connection);

            //SELECT Publisher.name, COUNT(*) AS 'number of books' FROM Publisher, book WHERE Publisher.PublisherId = book.PublisherId GROUP BY  Publisher.name


            Console.ReadKey();
        }
        private static void NumberBooksForPublisher(SqlConnection connection)
        {
            try
            {
                var query = "SELECT Publisher.name, COUNT(*) AS 'NumberBooks' FROM Publisher, book WHERE Publisher.PublisherId = book.PublisherId GROUP BY  Publisher.name";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var currentRow = dataReader;

                    var nrBooks = currentRow["NumberBooks"];
                    var name = currentRow["Name"];


                    Console.WriteLine($"{nrBooks} - {name}");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
        private static void Top10Publishers(SqlConnection connection)
        {
            try
            {
                var query = "select * from Publisher where PublisherId <= 10";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var currentRow = dataReader;

                    var idPub = currentRow["PublisherId"];
                    var name = currentRow["Name"];


                    Console.WriteLine($"{idPub} - {name}");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
        private static void NumberRow(SqlConnection connection)
        {
            try
            {
                var query = "select COUNT(*) from Publisher";

                SqlCommand countCommand = new SqlCommand(query, connection);

                var count = countCommand.ExecuteScalar();

                Console.WriteLine($"Count is: {count}");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
