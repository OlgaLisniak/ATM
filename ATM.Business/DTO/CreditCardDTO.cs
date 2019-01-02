using System.ComponentModel.DataAnnotations;

namespace ATM.Business.DTO
{
    public class CreditCardDTO
    {
        [Required]
        [Display(Name = "Credit Card Number")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Number { get; set; }
    }
}
