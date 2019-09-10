using ProductManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.MyDbContext
{
    #region "ProductDBContext"
    public class ProductDBContext : DbContext
    {
        //Initializes a new instance of the <see cref="ProductDBContext"/> class.
        //<param name="options">The options.</param>
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        { 
        }

        //Gets or sets the product.
        public DbSet<Product> Product { get; set; }

        //Gets or sets the category.
        public DbSet<Category> Category { get; set; }
    }
    #endregion
}
