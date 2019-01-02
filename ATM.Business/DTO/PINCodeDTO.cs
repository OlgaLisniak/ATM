using System.ComponentModel.DataAnnotations;

namespace ATM.Business.DTO
{
    public class PINCodeDTO
    {
        [Required]
        [Display(Name = "PIN Code")]
        [MaxLength(4)]
        [MinLength(4)]
        public string PINCode { get; set; }
    }
}
