using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using ProductManagement.Interfaces;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        #region "Private variables"
        private readonly IProductRepository _productRepository;
        #endregion

        #region "Constructor"
        //Initializes a new instance of the <see cref="ProductController"/> class.
        //<param name="productRepository">The product repository.</param>
        // <param name="context">The context.</param>
        public ProductController(IProductRepository productRepository) => _productRepository = productRepository;
        #endregion

        #region "Index"
        [Route("/")]
        [Route("Index")]
        //List all products.
        //Includeing search and pagination.
        public IActionResult Index(int page = 1, int pageSize = 3, string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                PagedList<Product> products = new PagedList<Product>(_productRepository.SearchProduct(search), page, pageSize);
                return View("Index", products);
            }

            PagedList<Product> model = new PagedList<Product>(_productRepository.GetProducts(), page, pageSize);
            return View("Index", model);
        }
        #endregion

        #region "Details"
        [Route("Details")]
        //Detailses the specified identifier.
        //<param name="id">The identifier.</param>
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                Response.StatusCode = 404;
                return View("ProductNotFound");
            }
            else
            {
                Product product = _productRepository.GetSingleProduct(id.Value);

                //if product id is not available in database then render ProductNotFound view.
                if (product == null)
                {
                    Response.StatusCode = 404;
                    return View("ProductNotFound", id.Value);
                }
            }
            
            return View(_productRepository.GetSingleProduct(id));
        }
        #endregion

        #region "Save"
        [HttpGet]
        [Route("Save")]
        //Add or edit the products according to id.
        //<param name="id">The identifier.</param>
        public IActionResult Save(int? id)
        {
            var product = _productRepository.GetSingleProduct(id);

            ViewBag.CategoryList = _productRepository.GetCategoryList();

            if (id == 0)
                product = new Product();

            if (product == null || id == null)
                return View("PageNotFound");

            return View(product);
        }

        [HttpPost]
        [Route("Save")]
        /// <summary>Saves the specified product according to condition.</summary>
        /// <param name="product">The product.</param>
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.SaveProduct(product);
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region "Delete"
        [HttpGet]
        [Route("Delete")]
        //Deletes the specified identifier.
        //<param name="id">The identifier.</param>
        public IActionResult Delete(int? id)
        {
            var product = _productRepository.GetSingleProduct(id);

            if( id == null || product == null)
                return View("PageNotFound");

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Delete")]
        //Deletes the specific product.
        //<param name="id">The identifier.</param>
        public IActionResult DeleteConfirm(int? id)
        {
            _productRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}