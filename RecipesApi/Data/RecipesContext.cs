using Microsoft.EntityFrameworkCore;
using RecipesApi.Models;

namespace RecipesApi.Data {
	public class RecipesContext : DbContext {
		public DbSet<User> Users { get; set; }
		public DbSet<Recipe> Recipes { get; set; }

		// TODO: actually connect to database...
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source=");
	}
}