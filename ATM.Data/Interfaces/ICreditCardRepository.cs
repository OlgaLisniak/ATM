using ATM.Data.Models;
using System;

namespace ATM.Data.Interfaces
{
    public interface ICreditCardRepository : IDisposable
    {
        bool IsActive(int id);
        int GetCreditCardIdByNumber(string number);
        CreditCard GetCreditCard(string number);
        CreditCard GetCreditCard(int id);
        string GetPINCode(int id);
        void BlockCreditCard(int id);
        double GetBalance(int id);
    }
}
