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

        public bool Add(Customer entity)
        {
            throw new NotImplementedException();
        }
        public bool Edit(Customer entity)
        {
            throw new NotImplementedException();
        }
        public bool Delete(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
