using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.DataModels;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MIS442Store.DataLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product Get(int id)
        {
            Product p = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MIS442_TMiller"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spProduct_Get";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p = new Product();
                            p.ProductID = int.Parse(reader["ProductID"].ToString());
                            p.ProductCode = reader["ProductCode"].ToString();
                            p.ProductName = reader["ProductName"].ToString();
                            p.ProductVersion = decimal.Parse(reader["ProductVersion"].ToString());
                            p.ProductReleaseDate = DateTime.Parse(reader["ProductReleaseDate"].ToString());
                        }
                    }
                }
            }
            return p;
        }

        public List<Product> GetList()
        {
            List<Product> productList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MIS442_TMiller"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spGet_List";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product p = new Product();
                            p.ProductID = int.Parse(reader["ProductID"].ToString());
                            p.ProductCode = reader["ProductCode"].ToString();
                            p.ProductName = reader["ProductName"].ToString();
                            p.ProductVersion = decimal.Parse(reader["ProductVersion"].ToString());
                            p.ProductReleaseDate = DateTime.Parse(reader["ProductReleaseDate"].ToString());
                            productList.Add(p);
                        }
                    }
                }
            }
            return productList;
        }

        public void Save(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MIS442_TMiller"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    
                    command.Connection = connection;
                    command.CommandText = "spInsert_Update";
                    command.CommandType = CommandType.StoredProcedure;

                    if (product.ProductID != 0)
                    {
                        command.Parameters.AddWithValue("@ProductID", product.ProductID);
                    }
                    
                    command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@ProductVersion", product.ProductVersion);
                    command.Parameters.AddWithValue("@ProductReleaseDate", product.ProductReleaseDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}