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
    public class Car : IReadable<Car>
    {
        public int Id { get; set; }

        public string? RegistrationNumber { get; set; }

        public Owner? Owner { get; set; }

        public Car Create(SqlDataReader reader)
        {
            var car = new Car
            {
                Id = reader.GetInt32("Id"),
                RegistrationNumber = reader.GetString("RegistrationNumber")
            };

            if(!reader.IsDBNull("OwnerId")) {
                var owner = new Owner
                {
                    Id = reader.GetInt32("OwnerId"),
                    Name = reader.GetString("Name"),
                    Surname = reader.GetString("Surname"),
                };

                car.Owner = owner;
            }

            return car;
        }
    }
}
