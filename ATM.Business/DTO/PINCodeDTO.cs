using System.ComponentModel.DataAnnotations;

namespace ATM.Business.DTO
{
    public class PINCodeDTO
    {
        [Required]
        [Display(Name = "PIN Code")]
        [MaxLength(4, ErrorMessage = "The Pin Code cannot exceed 4 digits. ")]
        [MinLength(4, ErrorMessage = "The Pin Code cannot be less than 4 digits. ")]
        public string PINCode { get; set; }
    }
}
