using ATM.Business.DTO;
using System.Web.Mvc;

namespace ATM.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            var error = new ErrorDTO("Not Found");
            return View(error);
        }

        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            var error = new ErrorDTO("You don't have permission to access");
            return View(error);
        }
    }
}