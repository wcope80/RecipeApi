using RecipeApi.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RecipeApi.WebApi.Services.Authentication.Interfaces
{
    public interface IUserContext
    { 
        DbSet<User> Users { get; set; }
    }




}
