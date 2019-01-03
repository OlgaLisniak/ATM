using System;

namespace ATM.Business.DTO
{
    public class OperationResultBalance
    {
        public int CardId { get; set; }
        public int OperationId { get; set; }
        public DateTime Date { get; set; }
    }
}
