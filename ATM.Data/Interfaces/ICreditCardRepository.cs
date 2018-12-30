using ATM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Data.Interfaces
{
    public interface ICreditCardRepository : IDisposable
    {
        bool IsActive(int id);
        int GetCardIdByNumber(string number);
        CreditCard GetCreditCard(string number);
        CreditCard GetCreditCard(int id);
    }
}
