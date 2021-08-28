namespace RecipesApi.Models{
	public class Recipe : BaseModel {
		public string Title { get; set; }
		public string Content { get; set; }
		public string ImageUrl { get; set; }
		public int CreatorId { get; set; }
		public User Creator { get; set; }
	}
}