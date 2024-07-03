using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SP_Trial.Models;

namespace SP_Trial.DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        internal object GetProductsByName(string productName)
        {
            throw new NotImplementedException();
        }
    }
}
