using Microsoft.AspNetCore.Mvc;
using EnvarterTakip.Data;
using EnvarterTakip.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;

namespace EnvarterTakip.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase{
    private readonly AppDbContext _context;
        public ProductController(AppDbContext context)//datanın bir örneğini alır
    {
        _context = context;//eşitler
    }

// Add
    [HttpPost("add")]
    public async Task<IActionResult> AddProduct(Product product)
    {
        try
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

//delete
 [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if(product == null)
        {
            return NotFound();
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }
//update
[HttpPut("{id}")]
public async Task<IActionResult> Update(int id, Product updateProduct){
    var uProduct = await _context.Products.FindAsync(id);
    if(uProduct == null){
        return NotFound();
    }

    uProduct.Name = updateProduct.Name;
    uProduct.Price = updateProduct.Price;
    uProduct.Stock = updateProduct.Stock;

    await _context.SaveChangesAsync();
    return Ok(uProduct);

}
//listeleme
[HttpGet]
public async Task<IActionResult> List(){
    var lProduct = await _context.Products.ToListAsync();
    return Ok(lProduct);
}

}
