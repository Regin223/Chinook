using System;
using System.Collections.Generic;
using Chinook.Models;
using Chinook.Repositories;

namespace Chinook
{
    /// <summary>
    /// Class <c>Progam</c> displays the results for each nine queries in the assignment.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string dataSource = "N-SE-01-3007\\SQLEXPRESS"; // Marcus
            //string dataSource = "DESKTOP-MKQHIVD\\SQLEXPRESS"; // Måns
            string connectionString = ConnectionStringHelper.GetConnectionString(dataSource);
            CustomerRepository cr = new CustomerRepository(connectionString);
           
            // One
            Console.WriteLine("One\n----------------------------------------");
            List<Customer> customerList = (List<Customer>)cr.GetAll();
            foreach (Customer cust in customerList)
            {
                Console.WriteLine(cust.FirstName);
            }
            
            //Two
            Console.WriteLine("\nTwo\n----------------------------------------");
            Customer customer = cr.GetById(2);
            Console.WriteLine(customer.FirstName);
            
            // Three
            Console.WriteLine("\nThree\n--------------------------------------");
            List<Customer> customerListTwo = cr.GetCustomerByName("Marc");
            foreach (Customer c in customerListTwo)
            {
                Console.WriteLine(c.FirstName);
            }

            //Four
            Console.WriteLine("\nFour\n---------------------------------------");
            List<Customer> customerPageList = cr.GetCustomerPage(2, 5);
            foreach (Customer c in customerPageList)
            {
                Console.WriteLine($"First name: {c.FirstName} and Country: {c.Country}");
            }

            //// UNCOMMENT TO TEST ADD AND EDIT FUNCTIONS
            //// Five 
            //Console.WriteLine("\nFive\n---------------------------------------");
            //Customer addCustomer = new Customer()
            //{
            //    FirstName = "Krille",
            //    LastName = "Larsson",
            //    Country = "Sweden",
            //    PostalCode = "35232",
            //    PhoneNumber = "0703697899",
            //    Email = "Ted.Svensson@gmail.com"
            //};
            //string returnValueAdd = cr.Add(addCustomer) ? "Add succeeded" : "Not able to add customer";
            //Console.WriteLine(returnValueAdd);

            ////Six
            //Console.WriteLine("\nSix\n----------------------------------------");
            //Customer customerToEdit = cr.GetById(60);
            //customerToEdit.LastName = "Svensson";
            //string returnValueEdit = cr.Edit(customerToEdit) ? "Update succeeded" : "Not able to update customer";
            //Console.WriteLine(returnValueEdit);

            // Seven
            Console.WriteLine("\nSeven\n--------------------------------------");
            List<CustomerCountry> customerCountries = cr.GetNumberOfCustomerInEachCountry();
            foreach(CustomerCountry customerCountry in customerCountries)
            {
                Console.WriteLine($"{customerCountry.Country} : {customerCountry.NumberOfCustomers}");
            }

            // Eight 
            Console.WriteLine("\nEight\n--------------------------------------");
            List<CustomerSpender> customerSpenders = cr.GetHighestSpenders();
            foreach(CustomerSpender customerSpender in customerSpenders)
            {
                Console.WriteLine($"{customerSpender.FirstName} - Total Spending: {customerSpender.TotalSpending}");
            }

            // Nine
            Console.WriteLine("\nNinen\n---------------------------------------");
            Customer customerGenre = cr.GetById(12);
            List<CustomerGenre> customerGenres = cr.GetCustomerMostPopularGenre(customerGenre);
            foreach (CustomerGenre genre in customerGenres)
            {
                Console.WriteLine($"Genre: {genre.Genre} - Count: {genre.GenreCount}");
            }
        }
    }
}
