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
            string connectionString = ConnectionStringHelper.GetConnectionString(true);
            CustomerRepository cr = new CustomerRepository(connectionString);
            List<Customer> customerList = (List<Customer>)cr.GetAll();
            // One
            foreach (Customer cust in customerList)
            {
                Console.WriteLine(cust.FirstName);
            }
            Console.WriteLine("-------------------");
            // Two
            Customer customer = cr.GetById(2);
            Console.WriteLine(customer.FirstName);
            // Three
            List<Customer> customerListTwo = cr.GetCustomerByName("Marc");
            Console.WriteLine("-------------------");
            foreach (Customer c in customerListTwo)
            {
                Console.WriteLine(c.FirstName);
            }
            Console.WriteLine("-------------------");
            // Four
            List<Customer> customerPageList = cr.GetCustomerPage(2, 5);
            foreach (Customer c in customerPageList)
            {
                Console.WriteLine($"First name: {c.FirstName} and Country: {c.Country}");
            }


        }
    }
}
