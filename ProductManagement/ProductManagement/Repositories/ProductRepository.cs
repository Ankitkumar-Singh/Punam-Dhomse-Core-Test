using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Interfaces;
using ProductManagement.Models;
using ProductManagement.MyDbContext;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region "Private variables"
        private readonly ProductDBContext context;
        #endregion

        #region "Constructor"
        //Initializes a new instance of the <see cref="ProductRepository"/> class
        // <param name="context">The context.</param>
        public ProductRepository(ProductDBContext context) => this.context = context;
        #endregion

        #region "GetProduct"
        //Get the list of product.
        public IEnumerable<Product> GetProducts() => context.Product.Include(p => p.Category);
        #endregion

        #region "GetSingleProduct"
        //Get the details of single product.
        public Product GetSingleProduct(int? id) => this.context.Product.Include(p => p.Category).SingleOrDefault(p => p.Id == id);
        #endregion

        #region "Save"
        //Add the product if not exits.
        //Edit the product if already exits.
        public Product SaveProduct(Product product)
        {
            if (product != null)
            {
                //Add product if not exists.
                if (product.Id == 0)
                    context.Product.Add(product);

                //Update product if already exits.
                else
                    context.Entry(product).State = EntityState.Modified;

                context.SaveChanges();
            }

            return product;
        }
        #endregion

        #region "DeleteProduct"
        //Delete the product according to id.
        public Product DeleteProduct(int? id)
        {
            Product product = context.Product.Include(p => p.Category)?.SingleOrDefault(p => p.Id == id);

            if (product != null)
            {
                context.Product.Remove(product);
                context.SaveChanges();
            }

            return product;
        }
        #endregion

        #region "Search"
        //Search according to Name and category of products.
        public IEnumerable<Product> SearchProduct(string search) => context.Product.Include(e => e.Category).
                                                                    Where(p => p.Name.Contains(search) || p.Category.Name.Contains(search));
        #endregion

        #region "GetCategoryList"
        //Get the list of categories form category table.
        public List<SelectListItem> GetCategoryList()
        {
            return context.Category.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }
        #endregion
    }
}
