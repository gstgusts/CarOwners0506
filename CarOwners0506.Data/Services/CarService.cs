using CarOwners0506.Data.Models;
using CarOwners0506.Data.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwners0506.Data.Services
{
    public class CarService
    {
        private DataAccessService _dataAccessService;
        public CarService(DataAccessService dataAccessService) {
            _dataAccessService = dataAccessService;
        }

        public IEnumerable<Car> GetCars() {
            return _dataAccessService.GetItems<Car>("select * from [dbo].[vCarWithOwner]");
        }

        public int Add(Car car)
        {
            return _dataAccessService.Add(car);
        }
    }
}
