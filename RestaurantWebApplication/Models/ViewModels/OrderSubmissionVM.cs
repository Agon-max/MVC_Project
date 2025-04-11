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
        [Required, Length(1, 255, ErrorMessage = "Ju lutem shkruani mbiemrin valid prej 1-255 karaktere!")]
        public string LastName { get; set; }
        [Required, StringLength(12, MinimumLength = 12,ErrorMessage = "Ju lutem shkruani numrin e telefonit valid prej 12-255 karaktere!")]
        public string PhoneNumber { get; set; }
        [Required, Length(7, 255, ErrorMessage = "Ju lutem shkruani mbiemrin valid prej 1-255 karaktere!")]
        [EmailAddress]
        public string Email { get; set; } 
        [Required]
        public string Address { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalPrice must be greater than zero.")]
        public decimal TotalPrice { get; set; }
        [Required]
        public List<int> Products { get; set; }
    }
}
