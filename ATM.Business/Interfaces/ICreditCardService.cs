using ATM.Business.DTO;

namespace ATM.Business.Interfaces
{
    public interface ICreditCardService
    {
        bool IsActive(CreditCardDTO creditCard);
        int GetCreditCardId(CreditCardDTO creditCard);
        bool IsCorrectPINCode(PINCodeDTO pinCodeDTO, int creditCardId);
        void BlockCreditCard(int id);
        CardInfoDTO GetCreditCardInfo(int id);
        void ChangeBalance(int id, int withdrawnAmount);
    }
}
