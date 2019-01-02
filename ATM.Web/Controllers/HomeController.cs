using ATM.Business.DTO;
using ATM.Business.Interfaces;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace ATM.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICreditCardService creditCardService;
        private readonly int MaxInvalidPinCodeAttempts;
        public int PINCodeAttempts;

        public HomeController(ICreditCardService _creditCardService)
        {
            creditCardService = _creditCardService;
            MaxInvalidPinCodeAttempts = Convert.ToInt32(ConfigurationManager.AppSettings["MaxInvalidPinCodeAttempts"]);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CreditCardDTO creditCard)
        {
            if (ModelState.IsValid)
            {
                var isActiveCard = creditCardService.IsActive(creditCard);

                if (isActiveCard)
                {
                    Response.Cookies["CardId"].Value = creditCardService.GetCreditCardId(creditCard).ToString();
                    Response.Cookies["CardId"].Expires = DateTime.Now.AddMinutes(5);

                    return View("PINCode");
                }
                else
                {
                    var message = "Your Credit Card Is Blocked";
                    var error = new ErrorDTO(message);

                    return View("Error", error);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PINCodePost(PINCodeDTO model)
        {
            if (ModelState.IsValid)
            {
                var cardId = Convert.ToInt32(Request.Cookies["CardId"].Value);

                if (PINCodeAttempts < MaxInvalidPinCodeAttempts)
                {
                    if (creditCardService.IsCorrectPINCode(model, cardId))
                    {
                        return RedirectToAction("Index", "Operation");
                    }
                    else
                    {
                        PINCodeAttempts++;
                        return View("PINCode");
                    }
                    
                }
                else
                {
                    creditCardService.BlockCreditCard(cardId);

                    var message = "Your Credit Card Is Blocked";
                    var error = new ErrorDTO(message);

                    return View("Error", error);
                }
                
            }
            return View("PINCode");
        }

    }
}