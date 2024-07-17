using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SP_Trial.Models;

namespace SP_Trial.DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProductCount> CategoryProductCounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure keyless entity
            modelBuilder.Entity<CategoryProductCount>().HasNoKey();
        }
    }
}


//// ApplicationDbContext.cs
//using Microsoft.EntityFrameworkCore;
//using SP_Trial.Models;

//namespace SP_Trial.DataLayer
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext()
//        {
//        }

//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
//        {
//        }

//        public DbSet<Product> Products { get; set; }
//        public DbSet<User> Users { get; set; }
//        public DbSet<Category> Categories { get; set; }
//        public DbSet<CategoryProductCount> CategoryProductCounts { get; set; } // DbSet for keyless entity

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            // Configure keyless entity
//            modelBuilder.Entity<CategoryProductCount>().HasNoKey();
//        }
//    }
//}
