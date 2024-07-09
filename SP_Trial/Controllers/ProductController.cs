using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public IActionResult AddProduct()
    {
        var categories = _db.Categories.ToList();
        var model = new AddProductModel
        {
            Categories = categories.Select(c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryID.ToString() })
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult SaveProduct(AddProductModel model)
    {
        if (ModelState.IsValid)
        {
            var product = new Product
            {
                ProductName = model.ProductName,
                Price = model.Price,
                Description = model.Description,
                CategoryID = model.CategoryID.GetValueOrDefault(),
                Category = _db.Categories.Find(model.CategoryID)
            };

            _db.Products.Add(product);
            _db.SaveChanges();

            return RedirectToAction("ProductsList");
        }

        model.Categories = _db.Categories.Select(c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryID.ToString() });
        return View("AddProduct", model);
    }

    public IActionResult EditProduct(int ProductID)
    {
        var categories = _db.Categories.ToList();
        var productObj = _db.Products.FirstOrDefault(p => p.ProductID == ProductID);

        var model = new EditProductModel();
        model.ProductID = productObj.ProductID;
        model.ProductName = productObj.ProductName;
        model.Price = productObj.Price;
        model.Description = productObj.Description;
        model.CategoryID = productObj.CategoryID;
        model.Categories = categories.Select(c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryID.ToString() });

        return View(model);
    }

    [HttpPost]
    public IActionResult UpdateProduct(EditProductModel model)
    {
        var productObj = _db.Products.Where(p => p.ProductID == model.ProductID).FirstOrDefault();
        productObj.ProductName = model.ProductName;
        productObj.Price = model.Price;
        productObj.Description = model.Description;
        productObj.CategoryID = model.CategoryID;

        _db.SaveChanges();
        return RedirectToAction("ProductsList");

    }
    [HttpPost]
    public IActionResult DeleteProduct(int productId)
    {
        try
        {
            var productObj = _db.Products.FirstOrDefault(p => p.ProductID == productId);

            if (productObj == null)
            {
                return Json(new { success = false, message = "Product not found." });
            }

            _db.Products.Remove(productObj);
            _db.SaveChanges();

            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
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