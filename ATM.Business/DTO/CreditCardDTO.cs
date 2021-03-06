﻿using System.ComponentModel.DataAnnotations;

namespace ATM.Business.DTO
{
    public class CreditCardDTO
    {
        [Required]
        [Display(Name = "Credit Card Number")]
        [MaxLength(19, ErrorMessage = "The Credit Card Number cannot exceed 16 digits. ")]
        [MinLength(19, ErrorMessage = "The Credit Card Number cannot be less than 16 digits. ")]
        public string Number { get; set; }
    }
}
