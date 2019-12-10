using DataAcccess.Connection;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class PublisherRepository
    {
        public List<Publishers> GetAllPublishers()
        {
            List<Publishers> publishers = new List<Publishers>();

            try
            {
                var query = "select * from [Publishers]";

                var connection = ConnectionManager.GetConnection();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var currentRow = dataReader;

                    Publishers publisher = new Publishers();

                    publisher.PublisherId = (int)currentRow["PublisherId"];
                    publisher.Name = currentRow["Name"].ToString();

                    publishers.Add(publisher);

                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return publishers;
        }
    }
}
