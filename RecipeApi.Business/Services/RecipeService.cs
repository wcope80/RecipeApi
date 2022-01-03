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
        return await _recipeRepository.Get();            
      
    }
    public async Task<RecipeModel> GetRecipeByIdAsync(int id)
    {
        _logger.LogInformation("RecipeService.GetRecipeByIdAsync");
        return await _recipeRepository.GetRecipeByIdAsync(id);
          
    }
}