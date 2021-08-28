using System;

namespace RecipesApi.Models{
	public class User : BaseModel {
		public string Username { get; set; }
		public string Password { get; set; }
	}
}