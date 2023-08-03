using CarOwners0506.Data.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CarOwners0506.Data.Models.Dto
{
    public class CarsPerOwnerDto : IReadable<CarsPerOwnerDto>
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public int NumberOfCars { get; set; }

        public CarsPerOwnerDto Create(SqlDataReader reader)
        {
            return new CarsPerOwnerDto
            {
                Name = reader.GetString("Name"),
                Surname = reader.GetString("Surname"),
                NumberOfCars = reader.GetInt32("NumberOfCars")
            };
        }
    }
}
