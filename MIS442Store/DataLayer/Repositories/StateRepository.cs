using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.Repositories;
using System.Data.SqlClient;
using System.Configuration;

namespace MIS442Store.DataLayer.Repositories
{
    public class StateRepository : IStateRepository 
    {
        public List<USState> Get()
        {
            List<USState> states = new List<USState>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MIS442_TMiller"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            USState s = new USState();
                            s.code = reader["code"].ToString();
                            s.name = reader["name"].ToString();
                            states.Add(s);
                        }
                    }
                }
            }
            return states;
        }
    }
}