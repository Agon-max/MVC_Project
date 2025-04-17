using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApplication.Models.ViewModels
{
    public class OrderSubmissionVM
    {
        public OrderSubmissionVM()
        {
            Products = new List<int>();
        }

        [Required, Length(1, 255, ErrorMessage ="Ju lutem shkruani emrin valid prej 1-255 karaktere!")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } 
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public List<int> Products { get; set; }
    }
}
