using Microsoft.EntityFrameworkCore;
using RecipesApi.Models;

namespace RecipesApi.Data {
	public class RecipesContext : DbContext {
		public DbSet<User> Users { get; set; }
		public DbSet<Recipe> Recipes { get; set; }

		public RecipesContext(DbContextOptions<RecipesContext> options) : base(options) {}
	}
}