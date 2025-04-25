using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApplication.Data;
using RestaurantWebApplication.Models;
using RestaurantWebApplication.Models.ViewModels;

namespace RestaurantWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public UserController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

       public IActionResult Create()
        {
            return View();
        }
    }
}
