using ATM.Business.DTO;
using ATM.Business.Interfaces;
using ATM.Data.Interfaces;
using System;

namespace ATM.Business.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository creditCardRepository;

        public CreditCardService(ICreditCardRepository _creditCardRepository)
        {
            creditCardRepository = _creditCardRepository;
        }

        //checks whether the card is active
        public bool IsActive(CreditCardDTO creditCard)
        {
            int id = GetCreditCardId(creditCard);

            return creditCardRepository.IsActive(id);
        }
        
        public int GetCreditCardId(CreditCardDTO creditCard)
        {
            return creditCardRepository.GetCreditCardIdByNumber(creditCard.Number);
        }

        //checks whether the same lines of the entered pinCode and pinCode from the database
        public bool IsCorrectPINCode(PINCodeDTO pinCodeDTO, int creditCardId)
        {
           var pinCode = creditCardRepository.GetPINCode(creditCardId);

           return string.Equals(pinCode, pinCodeDTO.PINCode);
        }

        public void BlockCreditCard(int id)
        {
            creditCardRepository.BlockCreditCard(id);
        }

        //get balance and number of credit card
        public CardInfoDTO GetCreditCardInfo(int id)
        {
            var cardInfoDTO = new CardInfoDTO
            {
                CreditCardBalance = creditCardRepository.GetBalance(id),
                Date = DateTime.Now,
                CreditCardNumber = creditCardRepository.GetCreditCard(id).Number
            };

            return cardInfoDTO;
        }

        //change balance after cash withdrawal
        public void ChangeBalance(int id, int withdrawnAmount)
        {
            creditCardRepository.ChangeBalance(id, withdrawnAmount);
        }
    }
}
