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

            CustomerRepository cr = new CustomerRepository();
            Customer customer = new Customer();
            customer = cr.GetById(2);
            Console.WriteLine(customer.FirstName);
            
        }
    }
}
