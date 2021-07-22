
namespace Chinook.Models
{
    /// <summary>
    /// Class <c>CustomerGenre</c> represents a model for the query result for a genre count, 
    /// for a specific customer 
    /// </summary>
    public class CustomerGenre
    {
        public string Genre { get; set; }
        public int GenreCount { get; set; }
    }
}
