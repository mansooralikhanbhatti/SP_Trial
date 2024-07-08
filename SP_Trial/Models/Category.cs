using System.ComponentModel.DataAnnotations;

namespace SP_Trial.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
}
