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
            var balance = creditCardService.GetCreditCardInfo(cardId);

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
                var balance = creditCardService.GetCreditCardInfo(cardId).CreditCardBalance;
                var withdrawnAmount = int.Parse(cashWithdrawal.WithdrawnAmount);
                var date = DateTime.Now;

                if (withdrawnAmount <= balance)
                {
                    var resultCashWithdrawal = new OperationResultCashWithdrawal
                    {
                        CardId = cardId,
                        OperationId = id,
                        Date = date,
                        WithdrawnAmount = withdrawnAmount
                    };

                    operationService.AddRecordToOperationResult(resultCashWithdrawal);

                    creditCardService.ChangeBalance(cardId, withdrawnAmount);

                    var operationResult = new OperationResultDTO
                    {
                        Date = date,
                        CreditCardBalance = creditCardService.GetCreditCardInfo(cardId).CreditCardBalance,
                        CreditCardNumber = creditCardService.GetCreditCardInfo(cardId).CreditCardNumber,
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