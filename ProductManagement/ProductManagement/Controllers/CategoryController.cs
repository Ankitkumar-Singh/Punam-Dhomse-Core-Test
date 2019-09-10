using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using ProductManagement.Interfaces;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    [Route("Category")]
    public class CategoryController : Controller
    {
        #region "Private variables"
        private readonly ICategoryRepository _categoryRepository;
        #endregion

        #region "Constructor"
        //Initializes a new instance of the <see cref="CategoryController"/> class.
        // <param name="categoryrepository">The categoryrepository.</param>
        public CategoryController(ICategoryRepository categoryrepository) => _categoryRepository = categoryrepository;
        #endregion

        #region "Index"
        [Route("Index")]
        // List all the category available in database.
        //Include pagination.
        public IActionResult Index(int page = 1, int pageSize = 3)
        {
            PagedList<Category> model = new PagedList<Category>(_categoryRepository.GetCategories(), page, pageSize);
            return View("Index", model);
        }
        #endregion

        #region "Save"
        [Route("Save")]
        [HttpGet]
        //Saves the specified category and render the view according to id.
        // <param name="id">The identifier.</param>
        public IActionResult Save(int? id)
        {
            var category = _categoryRepository.GetCategory(id);

            if (id == 0)
                category = new Category();

            if (category == null || id == null)
                return View("PageNotFound");

            return View(category);
        }

        [Route("Save")]
        [HttpPost]
        //Saves the specified category according to condition.
        // <param name="category">The category.</param>
        public IActionResult Save(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.SaveCategory(category);
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region "Delete"
        [HttpGet]
        [Route("Delete")]
        // Deletes the specified identifier.
        // <param name="id">The identifier.</param>
        public IActionResult Delete(int? id)
        {
            var category = _categoryRepository.GetCategory(id);

            if (id == null || category == null)
                return View("PageNotFound");

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Delete")]
        // Deletes the category.
        // <param name="id">The identifier.</param>
        public IActionResult DeleteConfirm(int? id)
        {
            _categoryRepository.DeleteCategory(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}