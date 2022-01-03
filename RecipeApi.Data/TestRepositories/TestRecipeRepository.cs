using RecipeApi.Data.Interfaces;
using RecipeApi.Shared.Entities;

namespace RecipeApi.Data.TestRepositories;

public class TestRecipeRepository : IRecipeRepository
{
    private List<Recipe> _recipes = new List<Recipe>()
    {
        new Recipe() { Id = 1, Name = "Recipe 1"},
        new Recipe() { Id = 2, Name = "Recipe 2"}
    };

    public Task<List<Recipe>> GetRecipesAsync()
    {
        return Task.FromResult(_recipes);
    }

    public Task<Recipe> GetRecipeByIdAsync(int id)
    {
        try
        {
            var recipe = Task.FromResult(_recipes.FirstOrDefault(w => w.Id == id));
            return recipe;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
