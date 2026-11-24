namespace FinanceTracker.Api.Models;

public class Category
{
    public int Id { get; set; }
    public required string UserId { get; set; }
    public required string Name { get; set; }
    public required string Color { get; set; }
    public required CategoryType Type { get; set; }
}