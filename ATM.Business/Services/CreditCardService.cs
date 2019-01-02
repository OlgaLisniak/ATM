using ATM.Business.DTO;
using ATM.Business.Interfaces;
using ATM.Data.Interfaces;

namespace ATM.Business.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository creditCardRepository;

        public CreditCardService(ICreditCardRepository _creditCardRepository)
        {
            creditCardRepository = _creditCardRepository;
        }

        public bool IsActive(CreditCardDTO creditCard)
        {
            int id = GetCreditCardId(creditCard);

            return creditCardRepository.IsActive(id);
        }

        public int GetCreditCardId(CreditCardDTO creditCard)
        {
            return creditCardRepository.GetCreditCardIdByNumber(creditCard.Number);
        }

        public bool IsCorrectPINCode(PINCodeDTO pinCodeDTO, int creditCardId)
        {
           var pinCode = creditCardRepository.GetPINCode(creditCardId);

           return string.Equals(pinCode, pinCodeDTO.PINCode);
        }

        public void BlockCreditCard(int id)
        {
            creditCardRepository.BlockCreditCard(id);
        }
    }
}
