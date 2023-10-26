using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitOfWorks;
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
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, ICustomerService customerService, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _customerService = customerService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {      
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                Customer customer1 = new Customer();
                customer1.FirstName = "Muzaffer";
                customer1.LastName = "Kaya";
                customer1.Gender = 'M';
                customer1.YearOfBirth = 2006;
                customer1.StreetAddress = "Mah. sok. no";
                customer1.PostalCode = "34500";
                customer1.City = "Istanbul";
                await _unitOfWork.GetRepository<Customer>().AddAsync(customer1);

                Customer customer2 = new Customer();
                customer2.FirstName = "Ozcan";
                customer2.LastName = "Cengiz";
                customer2.Gender = 'G';
                customer2.YearOfBirth = 2005;
                customer2.StreetAddress = "Mah. sok. no";
                customer2.PostalCode = "34500";
                customer2.City = "Istanbul";
                await _unitOfWork.GetRepository<Customer>().AddAsync(customer2);

                //throw new Exception("Error");

                Customer customer3 = new Customer();
                customer3.FirstName = "Koray";
                customer3.LastName = "Kaya";
                customer3.Gender = 'M';
                customer3.YearOfBirth = 2004;
                customer3.StreetAddress = "Mah. sok. no";
                customer3.PostalCode = "34500";
                customer3.City = "Istanbul";
                await _unitOfWork.GetRepository<Customer>().AddAsync(customer3);

                await _unitOfWork.CommitAsync();
                return View(await _customerService.GetAllCustomersAsync());
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return RedirectToAction(nameof(Privacy));
            }            
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