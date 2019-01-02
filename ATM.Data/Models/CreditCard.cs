using System.ComponentModel.DataAnnotations;

namespace ATM.Data.Models
{
    public class CreditCard
    {
        [Key]
        public int CardId { get; set; }

        [Required]
        public string Number { get; set; }
        
        [Required]
        [MaxLength(4)]
        public string PINCode { get; set; }
        public double Balance { get; set; }
        public bool IsActive { get; set; }
    }
}
