using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApplication.Models.ViewModels
{
	public class UserRegistrationVM
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
