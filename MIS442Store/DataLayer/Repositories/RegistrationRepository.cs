using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.DataModels;
using System.Data.SqlClient;
using System.Configuration;

namespace MIS442Store.DataLayer.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public List<Registration> GetRegistrations()
        {
            List<Registration> regList = new List<Registration>();
            Registration r = new Registration();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MIS442_TMiller"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Registration";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            r.RegistrationID = int.Parse(reader["RegistrationID"].ToString());
                            r.RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            r.RegistrationProductID = int.Parse(reader["RegistrationProductID"].ToString());
                            r.RegistrationSerialNumber = reader["RegistrationSerialNumber"].ToString();
                            r.RegistrationVerified = bool.Parse(reader["RegistrationVerified"].ToString());
                            r.RegistrationUserName = reader["RegistrationUserName"].ToString();
                            r.RegistrationAddress = reader["RegistrationAddress"].ToString();
                            r.RegistrationState = reader["RegistrationState"].ToString();
                            r.RegistrationCity = reader["RegistrationCity"].ToString();
                            r.RegistrationZip = reader["RegistrationZip"].ToString();
                            r.RegistrationPhone = reader["RegistrationPhone"].ToString();
                            regList.Add(r);
                        }
                    }
                }
            }
            return regList;
        }

        public List<Registration> GetUserRegistrations(string username)
        {
            List<Registration> regList = new List<Registration>();
            Registration r = new Registration();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MIS442_TMiller"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Registration";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            r.RegistrationID = int.Parse(reader["RegistrationID"].ToString());
                            r.RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            r.RegistrationProductID = int.Parse(reader["RegistrationProductID"].ToString());
                            r.RegistrationSerialNumber = reader["RegistrationSerialNumber"].ToString();
                            r.RegistrationVerified = bool.Parse(reader["RegistrationVerified"].ToString());
                            r.RegistrationUserName = reader["RegistrationUserName"].ToString();
                            r.RegistrationAddress = reader["RegistrationAddress"].ToString();
                            r.RegistrationState = reader["RegistrationState"].ToString();
                            r.RegistrationCity = reader["RegistrationCity"].ToString();
                            r.RegistrationZip = reader["RegistrationZip"].ToString();
                            r.RegistrationPhone = reader["RegistrationPhone"].ToString();
                            regList.Add(r);
                        }
                    }
                }
            }
            return regList;
        }

        public Registration GetRegistration(int id)
        {
            Registration r = new Registration();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MIS442_TMiller"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Registration";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            r.RegistrationID = int.Parse(reader["RegistrationID"].ToString());
                            r.RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            r.RegistrationProductID = int.Parse(reader["RegistrationProductID"].ToString());
                            r.RegistrationSerialNumber = reader["RegistrationSerialNumber"].ToString();
                            r.RegistrationVerified = bool.Parse(reader["RegistrationVerified"].ToString());
                            r.RegistrationUserName = reader["RegistrationUserName"].ToString();
                            r.RegistrationAddress = reader["RegistrationAddress"].ToString();
                            r.RegistrationState = reader["RegistrationState"].ToString();
                            r.RegistrationCity = reader["RegistrationCity"].ToString();
                            r.RegistrationZip = reader["RegistrationZip"].ToString();
                            r.RegistrationPhone = reader["RegistrationPhone"].ToString();
                        }
                    }
                }
            }
            return r;
        }

        public void SaveRegistration(Registration reg)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MIS442_TMiller"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Registration";
                    connection.Open();

                    if (reg.RegistrationID != 0)
                    {
                        command.Parameters.AddWithValue("@RegistrationID", reg.RegistrationID);
                    }

                    command.Parameters.AddWithValue("@RegistrationDate", reg.RegistrationDate);
                    command.Parameters.AddWithValue("@RegistrationProductID", reg.RegistrationProductID);
                    command.Parameters.AddWithValue("@RegistrationSerialNumber", reg.RegistrationSerialNumber);
                    command.Parameters.AddWithValue("@RegistrationVerified", reg.RegistrationVerified);
                    command.Parameters.AddWithValue("@RegistrationUserName", reg.RegistrationUserName);
                    command.Parameters.AddWithValue("@RegistrationAddress", reg.RegistrationAddress);
                    command.Parameters.AddWithValue("@RegistrationState", reg.RegistrationState);
                    command.Parameters.AddWithValue("@RegistrationCity", reg.RegistrationCity);
                    command.Parameters.AddWithValue("@RegistrationZip", reg.RegistrationZip);
                    command.Parameters.AddWithValue("@RegistrationPhone", reg.RegistrationPhone);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}