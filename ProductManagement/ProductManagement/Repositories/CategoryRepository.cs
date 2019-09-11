using Microsoft.EntityFrameworkCore;
using ProductManagement.Interfaces;
using ProductManagement.Models;
using ProductManagement.MyDbContext;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Repositories
{
    public class CatagoryRepository : ICategoryRepository
    {
        #region "Private variables"
        private readonly ProductDBContext context;
        #endregion

        #region "Constructor"
        //Initializes a new instance of the <see cref="CatagoryRepository"/> class.
        //<param name="context">The context.</param>
        public CatagoryRepository(ProductDBContext context) => this.context = context;
        #endregion

        #region "GetCategories"
        //Gets the list of categories.
        public IEnumerable<Category> GetCategories() => context.Category.Include(c => c.Product);
        #endregion

        #region "GetCategory"
        //Getcategories the specified identifier.
        //<param name="id">The identifier.</param>
        public Category GetCategory(int? id) => this.context.Category.SingleOrDefault(c => c.Id == id);
        #endregion

        #region "SaveCategory"
        //Saves the category according to  condition.
        //Add and edit according to id.
        public Category SaveCategory(Category category)
        {
            if (category != null)
            {
                //Add category if not exists.
                if (category.Id == 0)
                    context.Category.Add(category);

                //Update category if already exits.
                else
                {
                    context.Entry(category).State = EntityState.Modified;
                }
                context.SaveChanges();
            }

            return category;
        }
        #endregion

        #region "DeleteCategory"
        //Deletes the category.
        public Category DeleteCategory(int? id)
        {
            Category category = context.Category.Include(c => c.Product)?.SingleOrDefault(c => c.Id == id);

            if (category != null)
            {
                context.Category.Remove(category);
                context.SaveChanges();
            }

            return category;
        }
        #endregion
    }
}
