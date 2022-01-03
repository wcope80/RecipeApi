using RecipeApi.Shared.Entities;

namespace  RecipeApi.Shared.Models;

public class RecipeModel
{
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public List<Direction> Directions { get; set; } = new List<Direction>();
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}