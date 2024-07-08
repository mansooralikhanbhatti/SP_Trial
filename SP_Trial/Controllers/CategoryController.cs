using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SP_Trial.DataLayer;
using SP_Trial.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> CategoriesList()
    {
        var categories = await GetAllCategoriesAsync(string.Empty);
        return View(categories);
    }

    [HttpPost]
    public async Task<IActionResult> SearchCategories([FromBody] string keyword)
    {
        var categories = await GetAllCategoriesAsync(keyword);
        return PartialView("_CategoryListPartial", categories);
    }

    private async Task<List<Category>> GetAllCategoriesAsync(string keyword)
    {
        if (string.IsNullOrEmpty(keyword))
        {
            return await _db.Categories.FromSqlRaw("EXEC GetAllCategories").ToListAsync();
        }
        else
        {
            SqlParameter param = new SqlParameter("@p0", keyword);
            return await _db.Categories.FromSqlRaw("EXEC SearchCategory @p0", param).ToListAsync();
        }
    }
}
