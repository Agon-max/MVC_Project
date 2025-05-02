using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApplication.Data;
using RestaurantWebApplication.Models;
using RestaurantWebApplication.Models.ViewModels;

namespace RestaurantWebApplication.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _dbContext;

		public UserController(ILogger<HomeController> logger, ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
		{
			_logger = logger;
			_dbContext = dbContext;
			_userManager = userManager;
		}

		public IActionResult Create()
		{
			ViewBag.IsUserCreated = false;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(UserRegistrationVM model)
		{
			if (!ModelState.IsValid)
			{
				return View("Create");
			}

			var user = new IdentityUser
			{
				UserName = model.Email,
				Email = model.Email,
				EmailConfirmed = true,
				PhoneNumberConfirmed = false,
				LockoutEnabled = false
			};

			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				ViewBag.IsUserCreated = true;
				return View("Create");
			}

			if (result.Succeeded)
				return Ok(new { message = "User created successfully!" });

			foreach (var error in result.Errors)
				ModelState.AddModelError(string.Empty, error.Description);

			ViewBag.IsUserCreated = false;
			return View("Create");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
