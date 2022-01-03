using Microsoft.Extensions.Logging;
using RecipeApi.Business.Interfaces;
using RecipeApi.Data.Interfaces;
using RecipeApi.Shared.Entities;
using RecipeApi.Shared.Models;

namespace RecipeApi.Business.Services;

public class RecipeService : IRecipeService
{
    private readonly ILogger<RecipeService> _logger;
    private readonly IRecipeRepository _recipeRepository;
    public RecipeService(ILogger<RecipeService> logger, IRecipeRepository recipeRepository)
    {
        _logger = logger;
        _recipeRepository = recipeRepository;
    }

    public async Task<IEnumerable<Recipe>> GetRecipesAsync()
    {
        _logger.LogInformation("RecipeService.GetRecipeAsync");
        return await _recipeRepository.GetRecipesAsync();            
      
    }
    public async Task<RecipeModel> GetRecipeByIdAsync(int id)
    {
        _logger.LogInformation("RecipeService.GetRecipeByIdAsync");
        var recipeModel = new RecipeModel();
        var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
        recipeModel.Id = recipe.Id;
        recipeModel.Name = recipe.Name;
        return recipeModel;
          
    }
}