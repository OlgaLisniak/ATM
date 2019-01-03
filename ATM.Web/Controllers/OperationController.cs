using ATM.Business.DTO;
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

        public ActionResult Balance(int id)
        {
            var cardId = int.Parse(Request.Cookies["CardId"].Value);
            var balance = creditCardService.GetBalanceInfo(cardId);

            var resultBalance = new OperationResultBalance
            {
                CardId = cardId,
                OperationId = id,
                Date = DateTime.Now
            };

            operationService.AddRecordToOperationResult(resultBalance);

            return View(balance);
        }

        [HttpGet]
        public ActionResult CashWithdrawal(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CashWithdrawal(CashWithdrawalDTO cashWithdrawal)
        {
            return View();
        }
    }
}