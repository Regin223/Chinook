using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Repositories
{
    class ConnectionStringHelper
    {
        public static string GetConnectionString(bool user)
        {
            string dataSource;
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            if (user)
                dataSource = "N-SE-01-3007\\SQLEXPRESS";
            else
                dataSource = "DESKTOP-MKQHIVD\\SQLEXPRESS";
            connectionStringBuilder.DataSource = dataSource;
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true;
            return connectionStringBuilder.ConnectionString;

        }
    }
}
