using ProductManagement.Models;
using System.Collections.Generic;

namespace ProductManagement.Interfaces
{
    public interface ICategoryRepository
    {
        #region "Methods"
        IEnumerable<Category> GetCategories();
        Category GetCategory(int? id);
        Category SaveCategory(Category category);
        Category DeleteCategory(int? id);
        #endregion
    }
}
