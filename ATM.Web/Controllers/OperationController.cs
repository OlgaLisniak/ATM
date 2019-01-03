using ATM.Business.Interfaces;
using System;
using System.Web.Mvc;

namespace ATM.Web.Controllers
{
    public class OperationController : Controller
    {
        private readonly IOperationService operationService;
        private readonly ICreditCardService creditCardService;

        public OperationController(IOperationService _operationService, ICreditCardService _creditCardService)
        {
            operationService = _operationService;
            creditCardService = _creditCardService;
        }
        
        public ActionResult Index()
        {
            var operations = operationService.GetAll();

            return View(operations);
        }

        public ActionResult Balance()
        {
            var cardId = int.Parse(Request.Cookies["CardId"].Value);
            var balance = creditCardService.GetBalanceInfo(cardId);

            return View(balance);
        }

        public ActionResult Withdrawal()
        {
            return View();
        }

        public ActionResult Exit()
        {
            if (Request.Cookies["CardId"] != null)
            {
                Response.Cookies["CardId"].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}