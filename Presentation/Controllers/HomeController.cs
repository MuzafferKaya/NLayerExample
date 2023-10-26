using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using ServiceLayer.Services.Abstrack;
using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService _customerService;

        public HomeController(ILogger<HomeController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            Customer customer = new Customer();
            customer.FirstName = "Ozcan";
            customer.LastName = "Cengiz";
            customer.Gender = 'M';
            customer.YearOfBirth = 2005;
            customer.StreetAddress = "Yenikent mah.";
            customer.PostalCode = "34500";
            customer.City = "Istanbul";

            await _customerService.CreateCustomerAsync(customer);

            await _customerService.UpdateCustomerAsync(customer, 1);

            return View(await _customerService.GetAllCustomersAsync());
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