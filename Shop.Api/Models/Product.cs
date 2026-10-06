namespace Shop.Api.Models;

public class Product {
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public string Code {get; set;} = string.Empty;
    public string? Description {get; set;}
    public int CategoryId {get; set;}
    public decimal Price {get; set;}
    public Category Category {get; set;} = null!;
    public bool IsActive {get; set;} = true;
    public int StockQuantity {get; set;}
}