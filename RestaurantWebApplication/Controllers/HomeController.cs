using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApplication.Data;
using RestaurantWebApplication.Models;

namespace RestaurantWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Menu()
        {
            var foods = _dbContext.Foods.Include(r => r.FoodType).ToList();
            return View(foods);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact(bool? IsSent)
        {
            ViewBag.IsSent = IsSent == false;
            
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact data)
        {
            if (data == null)
                return RedirectToAction("Contact", "Home");

            data.CreatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                _dbContext.Contacts.Add(data);
                _dbContext.SaveChanges();

                return RedirectToAction("Contact", "Home", new { IsSent = true });
            }

            return View("Contact");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
