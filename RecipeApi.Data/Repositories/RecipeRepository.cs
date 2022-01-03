using RecipeApi.Data.Interfaces;
using RecipeApi.Shared.Entities;
using RecipeApi.Data.DBContexts;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace RecipeApi.Data.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly ILogger<RecipeRepository> _logger;
    private readonly RecipeApiContext _context;

    public RecipeRepository(ILogger<RecipeRepository> logger, RecipeApiContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<List<Recipe>> GetRecipesAsync()
    {
        _logger.LogInformation("GetRecipesAsync");
        var recipes = await _context.Recipes.ToListAsync();
        return recipes;
    }
    public async Task<Recipe> GetRecipeByIdAsync(int id)
    {
        try
        {
            _logger.LogInformation($"GetRecipeByIdAsync for id: { id }");
            var recipe = await _context.Recipes.FirstOrDefaultAsync(w => w.Id == id);
            return recipe;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to GetRecipeByIdAsync for id: { id }");
            return null;
        }
    }

}








