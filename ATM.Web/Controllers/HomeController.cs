using ATM.Business.Interfaces;
using ATM.Business.Services;
using ATM.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICreditCardService creditCardService;

        public HomeController(ICreditCardService _creditCardService)
        {
            creditCardService = _creditCardService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CreditCardVM creditCard)
        {
            if (ModelState.IsValid)
            {
                if (creditCardService.IsActive(creditCard))
                {
                    return View("PINCode");
                }
                else
                {
                    var message = "Your card is blocked";
                    var error = new ErrorVM(message);

                    return View("Error");
                }
            }

            return View();
        }

    }
}