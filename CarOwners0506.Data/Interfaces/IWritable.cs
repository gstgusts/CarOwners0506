using Microsoft.Data.SqlClient;

namespace CarOwners0506.Data.Interfaces
{
    public interface IWritable
    {
        string StoredProcedureName { get; }

        void AddParameters(SqlParameterCollection parameterCollection);
    }
}
