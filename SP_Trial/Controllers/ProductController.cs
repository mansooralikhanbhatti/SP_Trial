using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SP_Trial.DataLayer;

namespace SP_Trial.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;


        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult ProductsList()
        {
            var GetAllProducts = _db.Products.FromSqlRaw("GetAllProducts").ToList();
            return View(GetAllProducts);
        }
        [HttpPost]
        public IActionResult SearchProducts(string ProductName)
        {
            var products = _db.GetProductsByName(ProductName);
            return PartialView("_ProductSearchResults", products);
        }

    }
}
