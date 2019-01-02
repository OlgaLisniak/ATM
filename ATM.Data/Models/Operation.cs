using System.ComponentModel.DataAnnotations;

namespace ATM.Data.Models
{
    public class Operation
    {
        [Key]
        public int OperationId { get; set; }

        public string Name { get; set; }
    }
}
