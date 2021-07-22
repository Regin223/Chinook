using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Models
{
    /// <summary>
    /// Class <c>CustomerSpender</c> represents a model for the query result for total spending
    /// of a specific customer
    /// </summary>
    public class CustomerSpender
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public decimal TotalSpending { get; set; }
    }
}
