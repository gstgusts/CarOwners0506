using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwners0506.Data.Interfaces
{
    public interface IReadable<T>
    {
        T Create(SqlDataReader reader);
    }
}
