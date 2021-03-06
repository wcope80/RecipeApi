using RecipeApi.Shared.Entities;
using RecipeApi.Shared.Models;

namespace RecipeApi.Data.Interfaces;
public interface IRecipeRepository
{
    Task<List<Recipe>> GetRecipesAsync();
    Task<Recipe> GetRecipeByIdAsync(int id);
}

