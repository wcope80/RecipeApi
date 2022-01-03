namespace RecipeApi.WebApi.Services.Authentication.Interfaces;

using RecipeApi.WebApi.Models;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
}
