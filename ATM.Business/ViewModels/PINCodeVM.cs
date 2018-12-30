using System.ComponentModel.DataAnnotations;

namespace ATM.Business.ViewModels
{
    public class PINCodeVM
    {
        [Display(Name = "PIN Code")]
        public string PINCode { get; set; }
        public int CardId { get; set; }
    }
}
