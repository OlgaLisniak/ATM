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
        public ActionResult CashWithdrawal(int id, CashWithdrawalDTO cashWithdrawal)
        {
            if (ModelState.IsValid)
            {
                var cardId = int.Parse(Request.Cookies["CardId"].Value);
                var balance = creditCardService.GetBalanceInfo(cardId);
                var withdrawnAmount = int.Parse(cashWithdrawal.WithdrawnAmount);

                if (withdrawnAmount < balance.CreditCardBalance)
                {
                    var resultBalance = new OperationResultCashWithdrawal
                    {
                        CardId = cardId,
                        OperationId = id,
                        Date = DateTime.Now,
                        WithdrawnAmount = withdrawnAmount
                    };

                    operationService.AddRecordToOperationResult(resultBalance);

                    creditCardService.ChangeBalance(cardId, withdrawnAmount);

                    var operationResult = new OperationResultDTO
                    {
                        Date = DateTime.Now,
                        CreditCardBalance = creditCardService.GetBalanceInfo(cardId).CreditCardBalance,
                        CreditCardNumber = creditCardService.GetBalanceInfo(cardId).CreditCardNumber,
                        WithdrawnAmount = withdrawnAmount
                    };

                    return View("OperationResult", operationResult);
                }
                else
                {
                    var message = "Not Enough Money On Balance";
                    var error = new ErrorDTO(message);

                    return View("Error", error);
                }
            }
            return View();
        }
    }
}