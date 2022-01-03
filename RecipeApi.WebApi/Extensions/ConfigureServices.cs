using Microsoft.Extensions.DependencyInjection;
using RecipeApi.WebApi.Services.Authentication.Interfaces;
using RecipeApi.WebApi.Services.Authentication;

namespace RecipeApi.WebApi.Extensions
{
    public static class ConfigureServices
    {
        public static void AddWebApi(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IUserContext, UserContext>();
        }
    }
}
