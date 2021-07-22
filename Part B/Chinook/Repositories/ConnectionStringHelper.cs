using Microsoft.Data.SqlClient;

namespace Chinook.Repositories
{
    /// <summary>
    /// Class <c>ConnectionStringHelper</c> used to set up the connection string to a database
    /// </summary>
    class ConnectionStringHelper
    {
        /// <summary>
        /// Create the connection string to use to open database connection
        /// </summary>
        /// <param name="user">DataScource to use</param>
        /// <returns>A connection string</returns>
        public static string GetConnectionString(string dataSource)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = dataSource;
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true;
            return connectionStringBuilder.ConnectionString;

        }
    }
}
