using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using StockRegisterApp.DAL.DAO;

namespace StockRegisterApp.DAL.Gateway
{
    class ProductGateway
    {
        private SqlConnection connection;

        public ProductGateway()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
        }

        public string Save(Product aProduct)
        {
            connection.Open();
            string query = "INSERT INTO t_Product (Code, Name, Quentity) VALUES (@Code, @Name, @Quentity)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Code",aProduct.Code );
            cmd.Parameters.AddWithValue("@Name",aProduct.Name);
            cmd.Parameters.AddWithValue("@Quentity",aProduct.Quentity);

            int affectedrow = cmd.ExecuteNonQuery();
            connection.Close();
            if (affectedrow > 0)
            {
                return "Product has been added";
            }
            return "Error!!";
        }

        public bool HasThisCode(string code)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Product WHERE Code='{0}'", code);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }

        public bool HasThisName(string name)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Product WHERE Name='{0}'", name);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }

        public List<Product> ShowAllProductInGrid()
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Product");
            SqlCommand cmd= new SqlCommand(query, connection);
            SqlDataReader aDataReader = cmd.ExecuteReader();

            List<Product> products = new List<Product>();

            if (aDataReader.HasRows)
            {
                while (aDataReader.Read())
                {
                    Product aProduct = new Product();
                    aProduct.Code = aDataReader[1].ToString();
                    aProduct.Name = aDataReader[2].ToString();
                    aProduct.Quentity = (int) aDataReader[3];
                    products.Add(aProduct);
                }
                connection.Close();
            }
            return products;
        }

        public int GetTotalQuentity()
        {
            int totalQuentity = 0;
            connection.Open();
            string query = string.Format("SELECT SUM (Quentity) FROM t_Product");
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader aDataReader = cmd.ExecuteReader();

            if (aDataReader.HasRows)
            {
                while (aDataReader.Read())
                {
                    totalQuentity = (int) aDataReader.GetValue(0);
                }
                
            }
            connection.Close();
            return totalQuentity;
        }
    }
}
