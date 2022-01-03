using RecipeApi.Business.Interfaces;
using RecipeApi.Business.Services;
using RecipeApi.Data.TestRepositories;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RecipeApi.Tests.BusinessTests
{
    public class RecipeServiceTests
    {
        private readonly IRecipeService _recipeService;

        public RecipeServiceTests()
        {
            var loggerFactory = new LoggerFactory();
            var logger = loggerFactory.CreateLogger<RecipeService>();
            var recipeRepository = new TestRecipeRepository();
            _recipeService = new RecipeService(logger, recipeRepository);
        }
        [Fact]
        public async Task Test1()
        {
            var Recipe = await _recipeService.GetRecipesAsync();
            Assert.NotNull(Recipe);
            Assert.NotStrictEqual(0, Recipe.Count());
        }

    }
}
