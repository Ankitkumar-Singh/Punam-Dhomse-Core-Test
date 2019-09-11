using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Controllers
{
    public class ErrorController : Controller
    {
        #region "Error"
        //HTTPs the status code handler to handle the 404 not found.
        //<param name="statusCode">The status code.</param>
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found.";
                    break;
            }

            return View("PageNotFound");
        }
        #endregion
    }
}