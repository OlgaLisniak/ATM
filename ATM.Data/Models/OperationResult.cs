using System;
using System.ComponentModel.DataAnnotations;

namespace ATM.Data.Models
{
    public class OperationResult
    {
        [Key]
        public int Id { get; set; }

        public int CardId { get; set; }
        public DateTime Date { get; set; }
        public int OperationId { get; set; }
    }
}
