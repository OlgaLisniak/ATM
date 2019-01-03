using System.ComponentModel.DataAnnotations;

namespace ATM.Business.DTO
{
    public class CashWithdrawalDTO
    {
        [Required]
        [MaxLength(5)]
        public string WithdrawnAmount { get; set; }
    }
}
