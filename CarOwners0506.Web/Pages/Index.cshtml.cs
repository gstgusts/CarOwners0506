using CarOwners0506.Data.Models;
using CarOwners0506.Data.Models.Dto;
using CarOwners0506.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarOwners0506.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly OwnerService _ownerService;

        public IEnumerable<Owner> Owners { get; set; }

        public IEnumerable<CarsPerOwnerDto> NumberOfCars { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            var connectionProvider = new SqlConnectionProvider(_configuration.GetConnectionString("CarsDbConnectionString"));
            var dataService = new DataAccessService(connectionProvider);

            _ownerService = new OwnerService(dataService);
        }

        public void OnGet()
        {
            Owners = _ownerService.GetOwners();

            NumberOfCars = _ownerService.GetNumberOfCars();
        }
    }
}