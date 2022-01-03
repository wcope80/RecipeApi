using Microsoft.AspNetCore.Mvc;
using RecipeApi.WebApi.Models;
using RecipeApi.WebApi.Helpers;
using RecipeApi.WebApi.Services.Authentication.Interfaces;
using RecipeApi.Business.Interfaces;
using RecipeApi.Shared.Entities;

namespace RecipeApi.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class RecipesController : Controller
{
    private readonly ILogger<RecipesController> _logger;
    private readonly IRecipeService _recipeService;

    public RecipesController(ILogger<RecipesController> logger, IRecipeService recipeService)
    {
        _logger = logger;
        _recipeService = recipeService;
    }

    [HttpGet]
    public async Task<IEnumerable<Recipe>> Get()
    {
        var recipes = await _recipeService.GetRecipesAsync();
        return recipes;
    }

}