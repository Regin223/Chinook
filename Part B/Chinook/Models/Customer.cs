using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public class Customer
    {
        /// <summary>
        /// Class <c>Customer</c> represent the model for a customer with necesrray properties 
        /// according to the assignment instruction
        /// </summary>
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
