using Chinook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Chinook.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private string _connectionString;
        
        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Customer GetById(int id)
        {
            Customer returnCustomer = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "Select CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer where CustomerId = @id";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer()
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = reader.IsDBNull(1) ? "null" : reader.GetString(1),
                                    LastName = reader.IsDBNull(2) ? "null" : reader.GetString(2),
                                    Country = reader.IsDBNull(3) ? "null" : reader.GetString(3),
                                    PostalCode = reader.IsDBNull(4) ? "null" : reader.GetString(4),
                                    PhoneNumber = reader.IsDBNull(5) ? "null" : reader.GetString(5),
                                    Email = reader.IsDBNull(6) ? "null" : reader.GetString(6)
                                };
                                returnCustomer = customer;
                            }

                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return returnCustomer;
        }
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customerList = new List<Customer>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "Select CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer()
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = reader.IsDBNull(1) ? "null" : reader.GetString(1),
                                    LastName = reader.IsDBNull(2) ? "null" : reader.GetString(2),
                                    Country = reader.IsDBNull(3) ? "null" : reader.GetString(3),
                                    PostalCode = reader.IsDBNull(4) ? "null" : reader.GetString(4),
                                    PhoneNumber = reader.IsDBNull(5) ? "null" : reader.GetString(5),
                                    Email = reader.IsDBNull(6) ? "null" : reader.GetString(6)
                                };
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customerList;

        }

        public List<Customer> GetCustomerByName(string firstName)
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "Select CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer where FirstName LIKE @name";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", firstName);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer()
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = reader.IsDBNull(1) ? "null" : reader.GetString(1),
                                    LastName = reader.IsDBNull(2) ? "null" : reader.GetString(2),
                                    Country = reader.IsDBNull(3) ? "null" : reader.GetString(3),
                                    PostalCode = reader.IsDBNull(4) ? "null" : reader.GetString(4),
                                    PhoneNumber = reader.IsDBNull(5) ? "null" : reader.GetString(5),
                                    Email = reader.IsDBNull(6) ? "null" : reader.GetString(6)
                                };
                                customerList.Add(customer);
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return customerList;
        }

        public List<Customer> GetCustomerPage(int limit, int offset)
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "Select CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer where CustomerId BETWEEN @limit AND @offset";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@limit", limit);
                        cmd.Parameters.AddWithValue("@offset", offset);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer()
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = reader.IsDBNull(1) ? "null" : reader.GetString(1),
                                    LastName = reader.IsDBNull(2) ? "null" : reader.GetString(2),
                                    Country = reader.IsDBNull(3) ? "null" : reader.GetString(3),
                                    PostalCode = reader.IsDBNull(4) ? "null" : reader.GetString(4),
                                    PhoneNumber = reader.IsDBNull(5) ? "null" : reader.GetString(5),
                                    Email = reader.IsDBNull(6) ? "null" : reader.GetString(6)
                                };
                                customerList.Add(customer);
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return customerList;

        }
        public List<CustomerCountry> GetNumberOfCustomerInEachCountry()
        {
            List<CustomerCountry> customersByCountries = new List<CustomerCountry>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT Country, COUNT(*) AS NumberInCountry FROM Customer GROUP BY Country ORDER BY NumberInCountry DESC";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerCountry customerByCountry = new CustomerCountry()
                                {
                                    Country = reader.IsDBNull(0) ? "null" : reader.GetString(0),
                                    NumberOfCustomers = reader.IsDBNull(1) ? 0 : reader.GetInt32(1)
                                };
                                customersByCountries.Add(customerByCountry);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return customersByCountries;
        }
        public List<CustomerSpender> GetHighestSpenders()
        {
            List<CustomerSpender> customerSpenders = new List<CustomerSpender>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT Customer.CustomerId, Customer.FirstName,Invoice.Total FROM Customer INNER JOIN Invoice ON Customer.CustomerId = Invoice.CustomerId " +
                        "ORDER BY Total DESC";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSpender customerSpender = new CustomerSpender()
                                {
                                    Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                    FirstName = reader.IsDBNull(1) ? "null" : reader.GetString(1),
                                    TotalSpending = reader.IsDBNull(0) ? 0 : reader.GetDecimal(2),
                                };
                                customerSpenders.Add(customerSpender);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return customerSpenders;
        }

        public bool Add(Customer entity)
        {
            bool returnValue = false;
            try
            {
                
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) " +
                        "VALUES (@firstName, @lastName, @country, @postalCode, @phone, @email)";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@firstName", entity.FirstName);
                        cmd.Parameters.AddWithValue("@lastName", entity.LastName);
                        cmd.Parameters.AddWithValue("@country", entity.Country);
                        cmd.Parameters.AddWithValue("@postalCode", entity.PostalCode);
                        cmd.Parameters.AddWithValue("@phone", entity.PhoneNumber);
                        cmd.Parameters.AddWithValue("@email", entity.Email);

                        returnValue = cmd.ExecuteNonQuery() > 0;
                    }
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return returnValue;
        }
        public bool Edit(Customer entity)
        {
            bool returnValue = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "UPDATE Customer SET FirstName = @firstName, LastName = @lastName, Country = @country, PostalCode = @postalCode, Phone = @phone, Email = @email " +
                        "where CustomerId = @id";
               
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", entity.Id);
                        cmd.Parameters.AddWithValue("@firstName", entity.FirstName);
                        cmd.Parameters.AddWithValue("@lastName", entity.LastName);
                        cmd.Parameters.AddWithValue("@country", entity.Country);
                        cmd.Parameters.AddWithValue("@postalCode", entity.PostalCode);
                        cmd.Parameters.AddWithValue("@phone", entity.PhoneNumber);
                        cmd.Parameters.AddWithValue("@email", entity.Email);

                        returnValue = cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return returnValue;
        }
  
    }
}
