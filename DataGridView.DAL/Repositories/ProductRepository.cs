using DataGridView.DAL.Helpers;
using DataGridView.DAL.Interfaces;
using DataGridView.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.DAL.Repositories
{
    public class ProductRepository : IProduct
    {
        public void Create(Product product)
        {
            var connection = new DbConnectionHelper().Connection;
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "insert into Students values(@Name,@Price)";

            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
      


            connection.Open();
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }

        public int Delete(Product product)
        {
            var connection = new DbConnectionHelper().Connection;
            List<Product> products = new List<Product>();


            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.CommandText=@"delete from Products where @Id";
            command.Parameters.AddWithValue("@Id", product.Id);
            connection.Open();
            connection.Open();
            var returnValue = command.ExecuteScalar();
            int rv = Convert.ToInt32(returnValue);
            command.Parameters.Clear();
            connection.Close();

            return rv;
        }

        public List<Product> GetProduct()
        {

            var connection = new DbConnectionHelper().Connection;
            List<Product> products = new List<Product>();


            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.CommandText = @"select * from Products";

            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var product = new Product();
                product.Id = reader.GetInt32(0);
                product.Name = reader.GetString(1); 
                product.Price = reader.GetInt32(2); 
               

                products.Add(product);
            }
            reader.Close();
            connection.Close();


            return products;
        }

        public void Update(Product product)
        {
            var connection = new DbConnectionHelper().Connection;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.CommandText = @"UPDATE Products SET Name=@Name, Price=@Price WHERE Id=@Id";
            command.Parameters.AddWithValue("@Id", product.Id);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
