using ATM.Business.Interfaces;
using ATM.Business.ViewModels;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace ATM.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICreditCardService creditCardService;
        private readonly int PINCodeAttempts;

        public HomeController(ICreditCardService _creditCardService)
        {
            creditCardService = _creditCardService;
            PINCodeAttempts = Convert.ToInt32(ConfigurationManager.AppSettings["PINCodeAttempts"]);
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
                var isActiveCard = creditCardService.IsActive(creditCard);

                if (isActiveCard)
                {
                    var pinCodeVM = new PINCodeVM
                    {
                        CardId = creditCardService.GetCreditCardId(creditCard)
                    };

                    return View("PINCode", pinCodeVM);
                }
                else
                {
                    var message = "Your Credit Card Is Blocked";
                    var error = new ErrorVM(message);

                    return View("Error", error);
                }
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PINCodePost(PINCodeVM pinCode)
        {

            if (ModelState.IsValid)
            {
                
            }
            return View();
        }

    }
}