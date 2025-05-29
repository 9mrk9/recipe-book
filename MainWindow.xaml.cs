using System.Windows;
using System.Windows.Input;

namespace recipe_book
{
  public partial class MainWindow : Window
  {
    private RecipeContext ctx = new();

    public MainWindow()
    {
      InitializeComponent();
      LoadRecipes();
    }

    private void LoadRecipes()
    {
      RecipeList.ItemsSource = ctx.Recipes.ToList();
    }

    private Recipe? GetSelectedRecipe() => RecipeList.SelectedItem as Recipe;

    private static void HandleNoRecipeSelected()
    {
      MessageBox.Show("Please select a recipe to perform this action.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    private void AddRecipe(object sender, RoutedEventArgs e)
    {
      var editor = new RecipeEditorWindow();
      if (editor.ShowDialog() == true) LoadRecipes();
    }
    private void EditRecipe(object sender, RoutedEventArgs e)
    {
      var recipe = GetSelectedRecipe();
      if (recipe == null)
      {
        HandleNoRecipeSelected();
        return;
      }

      var editor = new RecipeEditorWindow(recipe.Id);
      if (editor.ShowDialog() == true)
      {
        ctx = new();
        LoadRecipes();
      }
    }

    private void DeleteRecipe(object sender, RoutedEventArgs e)
    {
      var recipe = GetSelectedRecipe();
      if (recipe == null)
      {
        HandleNoRecipeSelected();
        return;
      }

      if (MessageBox.Show($"Are you sure you want to delete the recipe '{recipe.Title}'?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
      {
        return;
      }

      ctx.Recipes.Remove(recipe);
      ctx.SaveChanges();
      LoadRecipes();
    }
    private void OpenRecipe()
    {
      var recipe = GetSelectedRecipe();
      if (recipe == null)
      {
        HandleNoRecipeSelected();
        return;
      }

      var viewer = new RecipeDetailsWindow(recipe.Id);
      viewer.ShowDialog();
    }
    private void ViewRecipe(object sender, RoutedEventArgs e)
    {
      OpenRecipe();
    }

    private void ItemDoubleClick(object sender, MouseButtonEventArgs e)
    {
      OpenRecipe();
    }
  }
}