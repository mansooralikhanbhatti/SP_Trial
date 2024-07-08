using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SP_Trial.DataLayer;
using SP_Trial.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _db;

    public ProductController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> ProductsList()
    {
        var products = await GetAllProductsAsync(string.Empty);
        return View(products);
    }

    [HttpPost]
    public async Task<IActionResult> SearchProducts([FromBody] string keyword)
    {
        var products = await GetAllProductsAsync(keyword); 
        return PartialView("_ProductListPartial", products); 
    }

    private async Task<List<Product>> GetAllProductsAsync(string keyword)
    {
        if (string.IsNullOrEmpty(keyword))
        {
            return await _db.Products.FromSqlRaw("EXEC GetAllProducts").ToListAsync();
        }
        else
        {
            SqlParameter param = new SqlParameter("@p0", keyword);
            return await _db.Products.FromSqlRaw("EXEC SearchProducts @p0", param).ToListAsync();
        }
    }
}
