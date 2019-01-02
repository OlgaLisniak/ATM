using ATM.Business.Interfaces;
using System;
using System.Web.Mvc;

namespace ATM.Web.Controllers
{
    public class OperationController : Controller
    {
        private readonly IOperationService operationService;

        public OperationController(IOperationService _operationService)
        {
            operationService = _operationService;
        }
        
        public ActionResult Index()
        {
            var operations = operationService.GetAll();

            return View(operations);
        }

        public ActionResult Balance()
        {
            return View();
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
            return RedirectToAction("Index");
        }
    }
}