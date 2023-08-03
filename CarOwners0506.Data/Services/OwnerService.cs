using CarOwners0506.Data.Models;
using CarOwners0506.Data.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwners0506.Data.Services
{
    public class OwnerService
    {
        private DataAccessService _dataAccessService;
        public OwnerService(DataAccessService dataAccessService) {
            _dataAccessService = dataAccessService;
        }

        public IEnumerable<Owner> GetOwners() {
            return _dataAccessService.GetItems<Owner>("select * from [dbo].[Owner]");
        }

        public IEnumerable<CarsPerOwnerDto> GetNumberOfCars()
        {
            return _dataAccessService.GetItems<CarsPerOwnerDto>("select * from [dbo].[vCarsPerOwner]");
        }

    }
}
