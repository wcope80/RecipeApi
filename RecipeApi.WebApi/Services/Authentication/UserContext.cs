using RecipeApi.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RecipeApi.Shared.Entities;
using RecipeApi.WebApi.Services.Authentication.Interfaces;

namespace RecipeApi.WebApi.Services.Authentication
{

    public class UserContext : DbContext , IUserContext
    {       
        public DbSet<User> Users { get; set; }

        public ConnectionString _connectionString { get; }

        public UserContext(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(_connectionString.DbPath);

        
    }




}
