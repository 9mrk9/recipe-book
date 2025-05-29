using System.Windows;

namespace recipe_book
{
  public partial class RecipeEditorWindow : Window
  {
    private readonly int _recipeId;
    private readonly RecipeContext ctx = new();

    public RecipeEditorWindow(int recipeId = -1)
    {
      InitializeComponent();
      _recipeId = recipeId;

      if (_recipeId == -1)
      {
        Title = "Add New Recipe";
        return;
      }
      var recipe = ctx.Recipes.Find(_recipeId);

      if (recipe != null)
      {
        Title = "Edit Recipe";
        TitleBox.Text = recipe.Title;
        IngredientsBox.Text = recipe.Ingredients;
        InstructionsBox.Text = recipe.Instructions;
      }
    }

    private void SaveRecipe(object sender, RoutedEventArgs e)
    {
      var title = TitleBox.Text.Trim();
      var ingredients = IngredientsBox.Text.Trim();
      var instructions = InstructionsBox.Text.Trim();
      if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(ingredients) || string.IsNullOrEmpty(instructions))
      {
        MessageBox.Show("All fields must be filled out.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      if (title.Length < 3)
      {
        MessageBox.Show("Title must be at least 3 characters long.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      Recipe recipe;
      if (_recipeId == -1)
      {
        recipe = new Recipe { Title = title, Ingredients = ingredients, Instructions = instructions };
        ctx.Recipes.Add(recipe);
      }
      else
      {
        recipe = ctx.Recipes.Find(_recipeId)!;
        recipe.Title = title;
        recipe.Ingredients = ingredients;
        recipe.Instructions = instructions;
      }
      ctx.SaveChanges();
      DialogResult = true;
    }
  }
}
