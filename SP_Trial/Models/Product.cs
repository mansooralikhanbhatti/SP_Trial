using System.ComponentModel.DataAnnotations;

namespace SP_Trial.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

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
