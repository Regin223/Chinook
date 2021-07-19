using System;
using System.Collections.Generic;
using Chinook.Models;
using Chinook.Repositories;
using Microsoft.Data.SqlClient;

namespace Chinook
{
    class Program
    {
        static void Main(string[] args)
        {
            // True Marcus, False Måns
            string connectionString = ConnectionStringHelper.GetConnectionString(true);
            
            try
            {
                List<Customer> customerList = new List<Customer>();
                using (SqlConnection connection = new SqlConnection(connectionString))
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
                                    FirstName = reader?.GetString(1) ?? "null",
                                    LastName = reader?.GetString(2) ?? "null",
                                    Country = reader?.GetString(3) ?? "null",
                                    PostalCode = reader?.GetString(4) ?? "null",
                                    PhoneNumber = reader?.GetString(5) ?? "null",
                                    Email = reader?.GetString(6) ?? "null"
                                };
                                customerList.Add(customer);
                            }
                        }
                    }
                }
                foreach (Customer customer in customerList)
                {
                    Console.WriteLine(customer.FirstName);
                }
            }
            catch (SqlException ex)
            {
                // Log
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
