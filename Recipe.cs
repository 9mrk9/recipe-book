using System.ComponentModel.DataAnnotations;

namespace recipe_book
{
  public class Recipe
  {
    [Key]
    public int Id { get; set; }

    [Required, MinLength(3)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Ingredients { get; set; } = string.Empty;

    [Required]
    public string Instructions { get; set; } = string.Empty;
  }
}
