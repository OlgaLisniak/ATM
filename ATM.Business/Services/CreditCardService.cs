using ATM.Business.Interfaces;
using ATM.Business.ViewModels;
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

        public bool IsActive(CreditCardVM creditCard)
        {
            int id = GetCreditCardId(creditCard);

            return creditCardRepository.IsActive(id);
        }

        public int GetCreditCardId(CreditCardVM creditCard)
        {
            return creditCardRepository.GetCreditCardIdByNumber(creditCard.Number);
        }
    }
}
