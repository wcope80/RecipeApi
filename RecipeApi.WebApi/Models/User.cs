namespace RecipeApi.WebApi.Models;

using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;

    [JsonIgnore]
    public string Password { get; set; } = string.Empty;
}