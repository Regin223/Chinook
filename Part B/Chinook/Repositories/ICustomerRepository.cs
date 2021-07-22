using System.Collections.Generic;
using Chinook.Models;

namespace Chinook.Repositories
{
    /// <summary>
    /// Interface <c>ICustomerRepository</c> implementing IRepository type Customer
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        public List<Customer> GetCustomerByName(string firstName);

        public List<Customer> GetCustomerPage(int start, int stop);

        public List<CustomerCountry> GetNumberOfCustomerInEachCountry();

        public List<CustomerSpender> GetHighestSpenders();

        public List<CustomerGenre> GetCustomerMostPopularGenre(Customer customer);
    }
}
