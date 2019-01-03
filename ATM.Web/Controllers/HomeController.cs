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
                creditCard.Number = creditCard.Number.Replace("-", string.Empty);

                var isActiveCard = creditCardService.IsActive(creditCard);

                if (isActiveCard)
                {
                    Response.Cookies["CardId"].Value = creditCardService.GetCreditCardId(creditCard).ToString();
                    TempData["pinCodeAttempts"] = 0;

                    return View("PINCode");
                }
                else
                {
                    var message = "Your Credit Card Is Blocked Or Not Found";
                    var error = new ErrorDTO(message);

                    return View("Error", error);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PINCodePost(PINCodeDTO pinCodeDTO)
        {
            if (ModelState.IsValid)
            {
                var cardId = Convert.ToInt32(Request.Cookies["CardId"].Value);
                var PINCodeAttempts = Convert.ToInt32(TempData["pinCodeAttempts"]);

                if (PINCodeAttempts < MaxInvalidPinCodeAttempts)
                {
                    if (creditCardService.IsCorrectPINCode(pinCodeDTO, cardId))
                    {
                        return RedirectToAction("Index", "Operation");
                    }
                    else
                    {
                        ViewBag.Message = "Try again";
                        PINCodeAttempts++;
                        TempData["pinCodeAttempts"] = PINCodeAttempts;
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

        public ActionResult Exit()
        {
            if (Request.Cookies["CardId"] != null)
            {
                Response.Cookies["CardId"].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("Index");
        }

    }
}