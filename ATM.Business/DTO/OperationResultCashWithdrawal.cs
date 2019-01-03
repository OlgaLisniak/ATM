using System;

namespace ATM.Business.DTO
{
    public class OperationResultCashWithdrawal
    {
        public int CardId { get; set; }
        public int OperationId { get; set; }
        public DateTime Date { get; set; }
        public int WithdrawnAmount { get; set; }
    }
}
