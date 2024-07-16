// CategoryProductCount.cs
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SP_Trial.Models
{
    [Keyless]
    public class CategoryProductCount
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
    }
}
