﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApplication.Data;
using RestaurantWebApplication.Models;

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
                .OrderByDescending(r => r.FoodOrderStatusId)
                .ToList();
            return View(orders);
        }

        public IActionResult UpdateFoodOrderStatus(int? foodOrderId = 0, int? foodOrderStatusId = 0)
        {
            if (foodOrderId == 0 || foodOrderStatusId == 0)
                return Json(new
                {
                    status = true,
                    message = "Statusi u ndryshua me sukses!"
                });

            var currentFoodOrder = _dbContext.FoodOrders.FirstOrDefault(r => r.Id == foodOrderId && r.DeletedAt == null);

            if (foodOrderId == 0 || foodOrderStatusId == 0)
                return Json(new
                {
                    status = false,
                    message = "Porosia nuk u gjend! Sorry"
                });

            currentFoodOrder.FoodOrderStatusId = foodOrderStatusId ?? 1;
            currentFoodOrder.UpdatedAt = DateTime.UtcNow;

            _dbContext.FoodOrders.Update(currentFoodOrder);
            _dbContext.SaveChanges();

            return Json(new
            {
                status = true,
                message = "Statusi u ndryshua me sukses!"
            });


        }
    }
}
