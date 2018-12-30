using System.ComponentModel.DataAnnotations;

namespace ATM.Data.Models
{
    public enum OperationName
    {
        Balance, Withdrawal, Exit
    }
    public class Operation
    {
        [Key]
        public int OperationId { get; set; }

        public OperationName Name { get; set; }
    }
}
