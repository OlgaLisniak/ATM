using System;
using System.ComponentModel.DataAnnotations;

namespace ATM.Business.DTO
{
    public class CardInfoDTO
    {
        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Display(Name = "Date Today")]
        public DateTime Date { get; set; }

        [Display(Name = "Credit Card Balance")]
        public double CreditCardBalance { get; set; }
    }
}
