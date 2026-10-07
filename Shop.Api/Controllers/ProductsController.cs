using Microsoft.AspNetCore.Mvc;
using Shop.Api.Models;
using Shop.Api.Data;

namespace Shop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductsController : ControllerBase {
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context) {
        _context = context;
    }

    //admin
    [HttpGet]
    public List<Product> GetProducts() {
        return _context.Products.ToList();
    }

    //client
    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id) {
        var product = _context.Products.Find(id);
        if (product == null) {
            return NotFound();
        }
        return product;
    }

    [HttpPost]
    public Product AddProduct(Product product) {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }

    [HttpPut("{id}")]
    public ActionResult<Product> UpdateProduct(int id, Product product) {
        var existingProduct = _context.Products.Find(id);
        if (existingProduct == null) {
            return NotFound();
        }
        existingProduct.Name = product.Name;
        existingProduct.Code = product.Code;
        existingProduct.Description = product.Description;
        existingProduct.CategoryId = product.CategoryId;
        existingProduct.Price = product.Price;
        existingProduct.IsActive = product.IsActive;
        existingProduct.StockQuantity = product.StockQuantity;
        existingProduct.ImageUrl = product.ImageUrl;
        _context.SaveChanges();
        return existingProduct;
    }

    [HttpDelete("{id}")]
    public ActionResult<Product> DeleteProduct(int id) {
        var product = _context.Products.Find(id);
        if (product == null) {
            return NotFound();
        }
        product.IsActive = false;
        _context.SaveChanges();
        return product;
    }
}