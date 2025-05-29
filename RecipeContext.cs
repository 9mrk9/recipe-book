using Microsoft.EntityFrameworkCore;
using System.IO;

namespace recipe_book
{
  public class RecipeContext : DbContext
  {
    public DbSet<Recipe> Recipes => Set<Recipe>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
      var dbPath = Path.Combine(projectRoot, "recipes.db");

      optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
  }
}
