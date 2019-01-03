using System;
using System.ComponentModel.DataAnnotations;

namespace ATM.Business.DTO
{
    public class OperationResultDTO
    {
        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Withdrawn Amount")]
        public int WithdrawnAmount { get; set; }

        [Display(Name = "Credit Card Balance")]
        public double CreditCardBalance { get; set; }
    }
}
