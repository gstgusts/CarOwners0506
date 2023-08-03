using CarOwners0506.Data.Interfaces;
using CarOwners0506.Data.Models.Dto;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwners0506.Data.Models
{
    public class Owner : IReadable<Owner>
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public Owner Create(SqlDataReader reader)
        {
            return new Owner
            {
                Name = reader.GetString("Name"),
                Surname = reader.GetString("Surname"),
                Id = reader.GetInt32("Id")
            };
        }
    }
}
