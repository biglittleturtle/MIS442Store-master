using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MIS442Store.DataLayer.Repositories
{
    public class NewsRepository : INewsRepository
    {
        List<News> INewsRepository.GetList()
        {
            List<News> myList = new List<News>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM News";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            News items2 = new News();
                            items2.id = int.Parse(reader["ID"].ToString());
                            items2.title = reader["Title"].ToString();
                            items2.body = reader["Body"].ToString();
                            items2.author = reader["Author"].ToString();
                            items2.date = reader["DatePosted"].ToString();

                            myList.Add(items2);
                        }
                    }
                }
            }
            return myList;
        }       
    }
}