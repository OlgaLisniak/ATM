using ATM.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            var error = new ErrorVM("Not Found");
            return View(error);
        }

        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
}