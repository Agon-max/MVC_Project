using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApplication.Data;

namespace RestaurantWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        public OrderController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var orders = _dbContext.FoodOrders.Include(r => r.FoodOrderDetails)
                .ThenInclude(r => r.Food)
                .Include(r => r.FoodOrderStatus)
                .Where(r => r.DeletedAt == null)
                .ToList();
            return View();
        }
    }
}
