using CarOwners0506.Data.Models;
using CarOwners0506.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarOwners0506.Web.Pages
{
    public class CarModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly CarService _carService;

        public IEnumerable<Car> Cars { get; set; }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public CarModel(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionProvider = new SqlConnectionProvider(_configuration.GetConnectionString("CarsDbConnectionString"));
            var dataService = new DataAccessService(connectionProvider);

            _carService = new CarService(dataService);
        }

        public void OnGet()
        {
            Cars = _carService.GetCars();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Car == null)
            {
                Cars = _carService.GetCars();
                return Page();
            }

            var id = _carService.Add(Car);

            return RedirectToPage("./Car");
        }
    }
}
