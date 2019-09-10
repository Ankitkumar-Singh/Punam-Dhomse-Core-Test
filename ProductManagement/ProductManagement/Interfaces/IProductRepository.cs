using Microsoft.AspNetCore.Mvc.Rendering;
using ProductManagement.Models;
using System.Collections.Generic;

namespace ProductManagement.Interfaces
{
    public interface IProductRepository
    {
        #region "Methods"
        IEnumerable<Product> GetProducts();
        Product GetSingleProduct(int? id);
        Product SaveProduct(Product product);
        Product DeleteProduct(int? id);
        IEnumerable<Product> SearchProduct(string search);
        List<SelectListItem> GetCategoryList();
        #endregion
    }
}
