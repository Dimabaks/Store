using System.ComponentModel.DataAnnotations;

namespace Shop.Api.Models;

public class Product {
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public string Code {get; set;} = string.Empty;
    public string? Description {get; set;}
    public int CategoryId {get; set;}
    [Range(0.01, 999999999)]
    public decimal Price {get; set;}
    public Category? Category {get; set;}
    public bool IsActive {get; set;} = true;
    [Range(0, 999999999)]
    public int StockQuantity {get; set;}
    public string? ImageUrl {get; set;}
}