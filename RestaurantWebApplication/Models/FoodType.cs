namespace RestaurantWebApplication.Models
{
	public class FoodType
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public ICollection<Food> Foods { get; set; }
	}
}
