using CarOwners0506.Data.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwners0506.Data.Services
{
    public class DataAccessService
    {
        private readonly SqlConnectionProvider _connectionProvider;

        public DataAccessService(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public IEnumerable<T> GetItems<T>(string query, Dictionary<string, object>? parameters = null) where T : IReadable<T>, new()
        {
            return ExecuteSql<T>(query, parameters);
        }

        private IEnumerable<T> ExecuteSql<T>(string sql, Dictionary<string, object>? parameters = null) where T : IReadable<T>, new()
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                var cmd = connection.CreateCommand();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                if (parameters != null && parameters.Any())
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }

                try
                {
                    connection.Open();

                    var reader = cmd.ExecuteReader();

                    var items = new List<T>();

                    while (reader.Read())
                    {
                        items.Add(new T().Create(reader));
                    }

                    connection.Close();

                    return items;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public int Add<T>(T entity) where T : IWritable
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                try
                {
                    connection.Open();
                    var cmd = new SqlCommand(entity.StoredProcedureName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    entity.AddParameters(cmd.Parameters);

                    var outputParameter = new SqlParameter("@new_id", SqlDbType.Int);
                    outputParameter.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(outputParameter);

                    cmd.ExecuteNonQuery();

                    var newId = Convert.ToInt32(cmd.Parameters["@new_id"].Value);

                    connection.Close();

                    return newId;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
