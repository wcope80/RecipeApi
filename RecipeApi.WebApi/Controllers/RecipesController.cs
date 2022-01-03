using Microsoft.AspNetCore.Mvc;
using RecipeApi.WebApi.Models;
using RecipeApi.WebApi.Helpers;
using RecipeApi.WebApi.Services.Authentication.Interfaces;

namespace RecipeApi.Api.Controllers;

public class RecipesController : Controller
{
    private readonly ILogger<RecipesController> _logger;
        private readonly IRecipeService _recipeService;

        public RecipesController(ILogger<RecipesController> logger, IRecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
        }

}