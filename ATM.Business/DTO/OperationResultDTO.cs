using System;

namespace ATM.Business.DTO
{
    public class OperationResultDTO
    {
        public string CreditCardNumber { get; set; }
        public DateTime Date { get; set; }
        public int WithdrawnAmount { get; set; }
        public double CreditCardBalance { get; set; }
    }
}
