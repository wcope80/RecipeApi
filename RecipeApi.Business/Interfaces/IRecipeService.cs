using RecipeApi.Shared.Entities;
using RecipeApi.Shared.Models;

namespace RecipeApi.Business.Interfaces;

public interface IRecipeService
{
    Task<IEnumerable<Recipe>> GetRecipesAsync();
    Task<RecipeModel> GetRecipeByIdAsync(int id);

}

