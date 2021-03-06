﻿using System.ComponentModel.DataAnnotations;

namespace ATM.Data.Models
{
    public class CreditCard
    {
        [Key]
        public int CardId { get; set; }

        [Required]
        [MaxLength(16)]
        [MinLength(16)]
        public string Number { get; set; }
        
        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        public string PINCode { get; set; }

        public double Balance { get; set; }
        public bool IsActive { get; set; }
    }
}
