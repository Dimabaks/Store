using Microsoft.AspNetCore.Mvc;
using Shop.Api.Models;
using Shop.Api.Data;

namespace Shop.Api.Controllers;

[ApiController]
[Route("api/[controller]")] 

public class CategoriesController : ControllerBase {
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context) {
        _context = context;
    }

    //admin
    [HttpGet]
    public List<Category> GetCategories() {
        return _context.Categories.ToList();
    }

    //client
    [HttpGet("active")]
    public List<Category> GetActiveCategories() {
        return _context.Categories.Where(c => c.IsActive).ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Category> GetCategory(int id) {
        var category = _context.Categories.Find(id);
        if (category == null) {
            return NotFound();
        }
        return category;
    }

    [HttpPost]
    public Category AddCategory(Category category) {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return category;
    }

    [HttpPut("{id}")]
    public ActionResult<Category> UpdateCategory(int id, Category category) {
        var existingCategory = _context.Categories.Find(id);
        if(existingCategory == null) {
            return NotFound();
        }
        existingCategory.Name = category.Name;
        existingCategory.Code = category.Code;
        existingCategory.IsActive = category.IsActive;
        existingCategory.UpdatedAt = DateTime.UtcNow;
        existingCategory.ImageUrl = category.ImageUrl;
        existingCategory.ParentCategoryId = category.ParentCategoryId;
        _context.SaveChanges();
        return existingCategory;
    }

    [HttpDelete("{id}")]
    public ActionResult<Category> DeleteCategory(int id) {
        var category = _context.Categories.Find(id);
        if (category == null) {
            return NotFound();
        }
        category.IsActive = false;
        _context.SaveChanges();
        return category;
    }
}