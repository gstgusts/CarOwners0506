using Microsoft.Data.SqlClient;

namespace CarOwners0506.Data.Services
{
    public class SqlConnectionProvider
    {
        private string _connectionString;

        public SqlConnectionProvider()
        {
        }

        public SqlConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
