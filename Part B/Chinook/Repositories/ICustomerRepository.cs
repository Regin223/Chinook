using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.Models;

namespace Chinook.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public List<Customer> GetCustomerByName(string firstName);

        public List<Customer> GetCustomerPage(int start, int stop);

        public List<CustomerCountry> GetNumberOfCustomerInEachCountry();

        public List<CustomerSpender> GetHighestSpenders();

        public List<CustomerGenre> GetCustomerMostPopularGenre(Customer customer);
    }
}
