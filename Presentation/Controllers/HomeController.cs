using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Repository<Customer> _repository = new Repository<Customer>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            /*Customer customer = new Customer();
            customer.FirstName = "Ahmet";
            customer.LastName = "Emin";
            customer.Gender = 'M';
            customer.YearOfBirth = 2006;
            customer.StreetAddress = "Yenikent mah.";
            customer.PostalCode = "34500";
            customer.City = "Istanbul";

            await _repository.AddAsync(customer);*/

            /*var Customer = await _repository.GetByIdAsync(1);
            _repository.Delete(Customer);*/

            return View(/*await _repository.GetAllAsync()*/);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}