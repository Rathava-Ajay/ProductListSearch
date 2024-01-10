using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoSearch.Models;
using MySql.Data.MySqlClient;

namespace DemoSearch.Controllers
{
    public class HomeController : Controller
    {
        private ProductDBContext db = new ProductDBContext();

        public ActionResult Index()
        {

            List<ProductModel> ListProductModel = new List<ProductModel>();

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ProductConnectionStrings"].ConnectionString))
            {
                connection.Open();

               
                string query = "SELECT * FROM Products";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            ProductModel product = new ProductModel();

                           
                            product.ProductId = Convert.ToInt32(reader["ProductId"]);
                            product.ProductName = reader["ProductName"].ToString();
                            product.Size = reader["Size"].ToString();
                            product.Category = reader["Category"].ToString();
                            product.Price = reader["Price"].ToString();
                            product.MfgDate = reader["mfgDate"].ToString();
                            ListProductModel.Add(product);
                        }
                    }
                }
            }

            return View(ListProductModel);
        }

        [HttpPost]
        public ActionResult Search(string sProductName, string sSize, string sCategory)
        {

            List<ProductModel> searchResults = new List<ProductModel>();

            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ProductConnectionStrings"].ConnectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("SearchProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    
                    command.Parameters.AddWithValue("@sProductName", sProductName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@sSize", sSize ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@sCategory", sCategory ?? (object)DBNull.Value);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           
                            ProductModel product = new ProductModel();

                            
                            product.ProductId = Convert.ToInt32(reader["ProductId"]);
                            product.ProductName = reader["ProductName"].ToString();
                            product.Size = reader["Size"].ToString();
                            product.Category = reader["Category"].ToString();
                            product.Price = reader["Price"].ToString();
                            product.MfgDate = reader["mfgDate"].ToString();
                           
                            searchResults.Add(product);
                        }
                    }
                }
            }


            return Json(searchResults);
        }

    }
}