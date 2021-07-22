
namespace Chinook.Models
{
    /// <summary>
    /// Class <c>CustomerCountry</c> represent a model for the query result for how many customers
    /// from each country
    /// </summary>
    public class CustomerCountry
    {
        public string Country { get; set; }

        public int NumberOfCustomers { get; set; }
    }
}
