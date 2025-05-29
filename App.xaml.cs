using System.Windows;

namespace recipe_book
{
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      using (var db = new RecipeContext())
      {
        db.Database.EnsureCreated();
      }

      base.OnStartup(e);
    }
  }
}
