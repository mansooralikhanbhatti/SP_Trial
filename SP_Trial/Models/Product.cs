using System.ComponentModel.DataAnnotations;

namespace SP_Trial.Models
{
    public class Product
    {
        internal Category? Category;

        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }

        internal static object FromSqlRaw(string v)
        {
            throw new NotImplementedException();
        }

        internal static object FromSqlRaw(string v, string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
