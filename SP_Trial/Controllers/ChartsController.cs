using Microsoft.AspNetCore.Mvc;
using SP_Trial.DataLayer;
using System.Linq;

public class ChartsController : Controller
{
    private readonly ApplicationDbContext _db;

    public ChartsController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult ChartsList()
    {
        var products = _db.Products.ToList();

        var productNames = products.Select(p => p.ProductName).ToArray();
        var prices = products.Select(p => p.Price).ToArray();

        ViewBag.ProductNames = productNames;
        ViewBag.Prices = prices;

        return View();
    }
}