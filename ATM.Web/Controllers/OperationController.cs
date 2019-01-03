using ATM.Business.DTO;
using ATM.Business.Interfaces;
using System;
using System.Net;
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
            if (Request.Cookies["CardId"] != null)
            {
                var operations = operationService.GetAll();
                return View(operations);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            
        }

        public ActionResult Balance(int id)
        {
            if (Request.Cookies["CardId"] != null)
            {
                var cardId = int.Parse(Request.Cookies["CardId"].Value);
                var balance = creditCardService.GetCreditCardInfo(cardId);

                //create record about balance operation
                var resultBalance = new OperationResultBalance
                {
                    CardId = cardId,
                    OperationId = id,
                    Date = DateTime.Now
                };

                operationService.AddRecordToOperationResult(resultBalance);

                return View(balance);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        [HttpGet]
        public ActionResult CashWithdrawal(int id)
        {
            if (Request.Cookies["CardId"] != null)
            {
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
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
                    //create record about Cash Withdrawal operation
                    var resultCashWithdrawal = new OperationResultCashWithdrawal
                    {
                        CardId = cardId,
                        OperationId = id,
                        Date = date,
                        WithdrawnAmount = withdrawnAmount
                    };

                    operationService.AddRecordToOperationResult(resultCashWithdrawal);

                    //change credit card balance
                    creditCardService.ChangeBalance(cardId, withdrawnAmount);

                    //create operation report
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