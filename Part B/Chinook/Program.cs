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
            string connectionString = ConnectionStringHelper.GetConnectionString(false);
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
            // Five 
            Console.WriteLine("-------------------");
            Customer addCustomer = new Customer()
            {
                FirstName = "Ted",
                LastName = "Svensson",
                Country = "Sweden",
                PostalCode = "35232",
                PhoneNumber = "0703697899",
                Email = "Ted.Svensson@gmail.com"
            };
            //if (cr.Add(addCustomer))
            //{
            //    Console.WriteLine("Add completed");
            //}
            //else
            //{
            //    Console.WriteLine("Not able to add customer");
            //}
            //Six
            //Console.WriteLine("-------------------");
            //Customer Ted = cr.GetById(60);
            //Ted.LastName = "Karlsson";
            //string returnValue = cr.Edit(Ted) ? "Update success" : "Not able to update";
            //Console.WriteLine(returnValue);

            // Seven
            Console.WriteLine("-------------------");
            List<CustomerCountry> customerCountries = cr.GetNumberOfCustomerInEachCountry();
            foreach(CustomerCountry customerCountry in customerCountries)
            {
                Console.WriteLine($"{customerCountry.Country} : {customerCountry.NumberOfCustomers}");
            }

            // Eight 
            Console.WriteLine("-------------------");
            List<CustomerSpender> customerSpenders = cr.GetHighestSpenders();
            foreach(CustomerSpender customerSpender in customerSpenders)
            {
                Console.WriteLine($"{customerSpender.FirstName} - Total Spending: {customerSpender.TotalSpending}");
            }

        }
    }
}
