namespace RecipeApi.Shared.Entities;
public class Direction
{
    public int Id { get; set; } 
    public string Text { get; set; } = string.Empty;
    public int RecipeId {get; set;}
}