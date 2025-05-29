using System.Windows;

namespace recipe_book
{
  public partial class RecipeDetailsWindow : Window
  {
    public RecipeDetailsWindow(int recipeId)
    {
      InitializeComponent();
      var recipe = new RecipeContext().Recipes.Find(recipeId);
      if (recipe == null)
      {
        MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        Close();
        return;
      }
      Title = recipe.Title;
      TitleBlock.Text = recipe.Title;
      IngredientsBlock.Text = recipe.Ingredients;
      InstructionsBlock.Text = recipe.Instructions;
    }
  }
}
