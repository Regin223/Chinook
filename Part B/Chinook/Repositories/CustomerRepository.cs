using Chinook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace Chinook.Repositories
{
    /// <summary>
    /// Class <c>CustomerRepository</c> implementing ICustomerRepository
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private string _connectionString;
        
        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Get a specific customer from the database by Id
        /// </summary>
        /// <param name="id">CustomerId</param>
        /// <returns>A specific customer</returns>
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

        /// <summary>
        /// Get all customer from the database
        /// </summary>
        /// <returns>List of customers</returns>
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

        /// <summary>
        /// Get a specific custmer by name
        /// </summary>
        /// <param name="firstName">Customer first name</param>
        /// <returns>A list of customers</returns>
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

        /// <summary>
        /// Get a subset of the customer data from the database between the start and stop values
        /// </summary>
        /// <param name="start">Where to begin selcting customers</param>
        /// <param name="stop">Where to stop selecting customers</param>
        /// <returns>number of customers between the start and stop value</returns>
        public List<Customer> GetCustomerPage(int start, int stop)
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "Select CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer where CustomerId BETWEEN @start AND @stop";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@start", start);
                        cmd.Parameters.AddWithValue("@stop", stop);
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

        /// <summary>
        /// Get number of customers in each country (high to low)
        /// </summary>
        /// <returns>a list of customerCountry</returns>
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

        /// <summary>
        /// Get the customers who are the higest spenders (high to low)
        /// </summary>
        /// <returns>A list of CustomerSpenders</returns>
        public List<CustomerSpender> GetHighestSpenders()
        {
            List<CustomerSpender> customerSpenders = new List<CustomerSpender>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT Customer.CustomerId, Customer.FirstName, sum(Invoice.Total) AS TotalSpent FROM Customer INNER JOIN Invoice ON " +
                        "Customer.CustomerId = Invoice.CustomerId GROUP BY Customer.CustomerId, Customer.FirstName " +
                        "ORDER BY TotalSpent DESC";
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

        /// <summary>
        /// Get the most popular genre for a specific customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>A list of CostumerGenre</returns>
        public List<CustomerGenre> GetCustomerMostPopularGenre(Customer customer)
        {
            List<CustomerGenre> customerGenreList = new List<CustomerGenre>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT Genre.Name as Genre,count(Genre.Name) as GenreCount FROM Genre INNER JOIN Track on Track.GenreId = Genre.GenreId " +
                        "INNER JOIN InvoiceLine on InvoiceLine.TrackId = Track.TrackId " +
                        "INNER JOIN Invoice on Invoice.InvoiceId = InvoiceLine.InvoiceId " +
                        "INNER JOIN Customer on Customer.CustomerId = Invoice.CustomerId " +
                        "where Customer.CustomerId = @id " +
                        "Group BY Genre.Name " +
                        "Order By GenreCount DESC";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", customer.Id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerGenre customerGenre = new CustomerGenre()
                                {
                                    Genre = reader.IsDBNull(1) ? "null" : reader.GetString(0),
                                    GenreCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(1),
                                    
                                };
                                customerGenreList.Add(customerGenre);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if(customerGenreList.Count() > 1)
            {
                List<CustomerGenre> temp = new List<CustomerGenre>();
                temp.Add(customerGenreList[0]);

                for (int i = 1; i < customerGenreList.Count; i++)
                {
                    if (customerGenreList[i].GenreCount < temp[0].GenreCount)
                        break;
                    else
                        temp.Add(customerGenreList[i]);

                }
                customerGenreList = temp;
            }
            

            return customerGenreList;
        }

        /// <summary>
        /// Add a new customer to the database
        /// </summary>
        /// <param name="entity">A customer</param>
        /// <returns>true if query succeded</returns>
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

        /// <summary>
        /// Update an existing customer
        /// </summary>
        /// <param name="entity">A customer</param>
        /// <returns>true if update succeded</returns>
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
