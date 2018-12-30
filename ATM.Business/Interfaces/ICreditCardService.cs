using ATM.Business.ViewModels;

namespace ATM.Business.Interfaces
{
    public interface ICreditCardService
    {
        bool IsActive(CreditCardVM creditCard);
    }
}
