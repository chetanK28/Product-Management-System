using MySql.Data.MySqlClient;
using ProductManagementSystem.Models;
using ProductManagementSystem.Repositories;

using System.Collections;
using System.Data;

namespace ProductManagementSystem.Repsitory
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connectionString;

        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void AddProduct(Product product)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("INSERT INTO  Product  (title, Description,Quantity,price) VALUES (@title, @description, @quantity, @price)", connection);
                    command.Parameters.AddWithValue("@title", product.Title);
                    command.Parameters.AddWithValue("@description", product.Description);
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    command.Parameters.AddWithValue("@price", product.Price);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeleteProduct(int ProductID)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("DELETE FROM Product WHERE Id = @ProductID", connection);
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable GetAllProduct()
        {
            List<Product> products = new List<Product>();
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("SELECT * FROM Product", connection);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            {
                                Product product = new Product();
                                product.Id = reader.GetInt32("Id");
                                product.Title = reader.GetString("Title");
                                product.Description = reader.GetString("Description");
                                product.Quantity = reader.GetInt32("Quantity");
                                product.Price = reader.GetDouble("Price");
                                products.Add(product);
                            }
                            
                           
                        }
                    }
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }

        public Product GetProductById(int id)
        {
            Product product = new Product();
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("SELECT * FROM Product WHERE Id = @ProductID", connection);
                    command.Parameters.AddWithValue("@ProductID", id);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            {
                                product.Id = reader.GetInt32("Id");
                                product.Title = reader.GetString("Title");
                                product.Description = reader.GetString("Description");
                                product.Quantity = reader.GetInt32("Quantity");
                                product.Price = reader.GetDouble("Price");
                            }
                        }
                    }
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
            return product;
        }

        public void UpdateProduct(Product product)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("UPDATE Product SET Title = @title, Description = @description, Quantity = @quantity, Price = @price WHERE Id = @ProductID", connection);
                    command.Parameters.AddWithValue("@title", product.Title);
                    command.Parameters.AddWithValue("@description", product.Description);
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@ProductID", product.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
