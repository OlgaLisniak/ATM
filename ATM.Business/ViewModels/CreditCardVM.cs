using System.ComponentModel.DataAnnotations;

namespace ATM.Business.ViewModels
{
    public class CreditCardVM
    {
        [Display(Name = "Credit Card Number")]
        [Required]
        public string Number { get; set; }
    }
}
