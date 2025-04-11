using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantWebApplication.Models
{
    public class FoodOrder
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string phoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int ForderOrderStatusId { get; set; }
        public FoodOrderStatus FoodOrderStatus { get; set; }

    }
}