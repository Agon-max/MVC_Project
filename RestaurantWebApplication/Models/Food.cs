using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApplication.Models
{
	public class Food
	{ 
		public Food() 
		{
            FoodOrderDetails = new List<FoodOrderDetail>();
        }	
		
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public int FoodTypeId { get; set; }
		public FoodType FoodType { get; set; }

        public List<FoodOrderDetail> FoodOrderDetails { get; set; }

    }
}
